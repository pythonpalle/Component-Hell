using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamePlayerWeaponManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private WeaponHandler playerWeaponHandler;
    
    [Header("Weapon Lists")]
    [SerializeField] private WeaponListData startingWeaponPrefabs;
    [SerializeField] private WeaponListData weaponPool;
    
    
    private List<Weapon> startingWeaponInstances = new List<Weapon>();

    public UnityEvent<Weapon> OnAddedWeapon;

    void Start()
    {
        playerWeaponHandler.OnWeaponAdded.AddListener(OnWeaponAdded);
        
        foreach (var startingWeapon in startingWeaponPrefabs.Weapons)
        {
            var startingWeaponInstance = playerWeaponHandler.AddWeapon(startingWeapon);
            OnAddedWeapon?.Invoke(startingWeaponInstance);
        }
    }

    private void OnWeaponAdded(Weapon addedWeapon)
    {
        startingWeaponInstances.Add(addedWeapon);
    }
}
