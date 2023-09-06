using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpeedComponent))]
[RequireComponent(typeof(DamageComponent))]
public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private WeaponController controller;
    [SerializeField] private SpeedComponent speedComponent;
    [SerializeField] private DamageComponent damageComponent;

    private void Awake()
    {
        weapons = GetComponentsInChildren<Weapon>().ToList();
        controller = GetComponent<WeaponController>();
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
            weapon.Setup(speedComponent, damageComponent);
            weapon.TryAttack();
        }
    }
}
