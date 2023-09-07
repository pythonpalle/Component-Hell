using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


public class WeaponHandler : MonoBehaviour
{
    [Header("Weapons Owned")]
    [SerializeField] private List<Weapon> weapons;
    
    [Header("Stats")]
    [SerializeField] private BaseAttackStats _stats;
    public BaseAttackStats Stats => _stats;

    private void Awake()
    {
        _stats = GetComponentInChildren<BaseAttackStats>();
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
            weapon.TryAttack(this);
        }
    }
}
