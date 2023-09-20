using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamePlayerWeaponManager : MonoBehaviour
{
    public static GamePlayerWeaponManager Instance;
    
    [Header("Player")]
    [SerializeField] private WeaponHandler playerWeaponHandler;
    
    [Header("Weapon Lists")]
    [SerializeField] private WeaponListData startingWeaponPrefabs;
    [SerializeField] private WeaponListData weaponPool;
    
    
    public List<Weapon> OwnedWeapons { get; private set; }= new List<Weapon>();
    public List<Weapon> PotentialWeaponPrefabs { get; private set; }= new List<Weapon>();

    public UnityEvent<Weapon> OnAddedWeapon;

    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    void Start()
    {
        InitialisePotentialWeapons();
        
        playerWeaponHandler.OnWeaponAdded.AddListener(OnWeaponAdded);
        
        foreach (var startingWeapon in startingWeaponPrefabs.Weapons)
        {
            var instance = AddWeapon(startingWeapon);
            instance.GetUpgradeManager().ApplyNextUpgrade();
        }
    }

    private void InitialisePotentialWeapons()
    {
        foreach (var weapon in weaponPool.Weapons)
        {
            PotentialWeaponPrefabs.Add(weapon);
        }
    }

    private void OnWeaponAdded(Weapon addedWeapon)
    {
        OwnedWeapons.Add(addedWeapon);
    }

    public Weapon AddWeapon(Weapon prefab)
    {
        PotentialWeaponPrefabs.Remove(prefab);
        var startingWeaponInstance = playerWeaponHandler.AddWeapon(prefab);
        OnAddedWeapon?.Invoke(startingWeaponInstance);

        return startingWeaponInstance;
    }
}
