using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


public class WeaponHandler : MonoBehaviour
{
    [Header("Weapons Owned")]
    [SerializeField] private List<Weapon> weapons;
    
    [Header("Controller")]
    [SerializeField] private WeaponController controller;

    [SerializeField] private WeaponStats _stats;
    public WeaponStats Stats => _stats;

    private void Awake()
    {
        _stats = GetComponentInChildren<WeaponStats>();
        weapons = GetComponentsInChildren<Weapon>().ToList();
    }

    private void Update()
    {
        bool wantsToShoot = !controller || controller.WantsToShoot();
        if (wantsToShoot)
        {
            TryAttackWithWeapons();
        }
    }

    void TryAttackWithWeapons()
    {
        foreach (var weapon in weapons)
        {
            weapon.Setup(this);
            weapon.TryAttack();
        }
    }
}
