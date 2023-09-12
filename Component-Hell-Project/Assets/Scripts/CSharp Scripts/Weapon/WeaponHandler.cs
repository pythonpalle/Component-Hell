using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class WeaponHandler : MonoBehaviour
{
    [Header("Weapons Owned")]
    [SerializeField] private List<Weapon> weapons;
    
    [SerializeField] private DataTransferManager dataTransferManager;

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
            if (weapon.CanAttack())
            {
                dataTransferManager.TransferAll(weapon);
                weapon.Attack(this);
            }
        }
    }
}
