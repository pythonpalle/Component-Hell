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
    
    
    private List<Weapon> startingWeaponInstances = new List<Weapon>();

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
        playerWeaponHandler.OnWeaponAdded.AddListener(OnWeaponAdded);
        
        foreach (var startingWeapon in startingWeaponPrefabs.Weapons)
        {
            AddWeapon(startingWeapon);
        }
    }

    private void OnWeaponAdded(Weapon addedWeapon)
    {
        startingWeaponInstances.Add(addedWeapon);
    }

    public void AddWeapon(Weapon prefab)
    {
        var startingWeaponInstance = playerWeaponHandler.AddWeapon(prefab);
        OnAddedWeapon?.Invoke(startingWeaponInstance);
    }
}
