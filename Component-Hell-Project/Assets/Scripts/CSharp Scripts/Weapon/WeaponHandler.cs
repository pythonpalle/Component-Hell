using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


public class WeaponHandler : MonoBehaviour, IMovementListener
{
    [Header("Weapons Owned")]
    [SerializeField] private List<Weapon> weapons;

    // [Header("Data")] 
    // [SerializeField] private WeaponDataHolder weaponData;

    [Header("Data Container")] 
    [SerializeField] private WeaponDataContainer _weaponDataContainer;
    
    [Header("Events")]
    public UnityEvent<WeaponDataHolder> OnUpdateData;
    public UnityEvent<Weapon> OnWeaponAdded;

    private Vector2 moveDirection;

    private void Awake()
    {
        weapons = GetComponentsInChildren<Weapon>().ToList();
    }

    private void Start()
    {
        foreach (var weaponInstance in weapons)
        {
            HandleInitialDataUpdate(weaponInstance);
        }
    }

    private void Update()
    {
        TryAttackWithWeapons();
    }

    void TryAttackWithWeapons()
    {
        foreach (var weapon in weapons)
        {
            weapon.TryAttack();
        }
    }

    public void AddWeapon(Weapon weaponPrefab)
    {
        var weaponInstance = Instantiate(weaponPrefab, transform);
        weapons.Add(weaponInstance);
        OnWeaponAdded?.Invoke(weaponInstance);

        HandleInitialDataUpdate(weaponInstance);
    }

    private void HandleInitialDataUpdate(Weapon weaponInstance)
    {
        WeaponDataContainer.TransferData(_weaponDataContainer.WeaponData, weaponInstance.WeaponDataContainer.WeaponData);
        
        //weaponInstance.UpdateData(_weaponDataContainer.weaponData);
        OnUpdateData.AddListener(weaponInstance.WeaponDataContainer.UpdateData);
    }

    public void OnMovementChange(Vector2 direction)
    {
        moveDirection = direction;
        foreach (var weapon in weapons)
        {
            weapon.UpdateDirection(direction);
        }
    }
}
