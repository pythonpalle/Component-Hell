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

    [Header("Data")] 
    [SerializeField] private WeaponDataHolder weaponData;
    
    [Header("Events")]
    public UnityEvent<WeaponDataHolder> OnUpdateData;

    private Vector2 moveDirection;

    private void Awake()
    {
        weapons = GetComponentsInChildren<Weapon>().ToList();
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
        weaponInstance.UpdateData(weaponData);
        OnUpdateData.AddListener(weaponInstance.UpdateData);
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
