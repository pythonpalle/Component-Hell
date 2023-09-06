using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class WeaponDamage : MonoBehaviour, IHasDamage
{
    private Weapon weapon;
    [SerializeField] private float damageValue = 1;
    
    public float Damage { get; set; }

    
    // private void OnEnable()
    // {
    //     Damage = damageValue;
    //     
    //     weapon = GetComponent<Weapon>();
    //     weapon.OnProjectileFired.AddListener(OnProjectileSpawned);
    // }
    //
    // private void OnDisable()
    // {
    //     weapon.OnProjectileFired.RemoveListener(OnProjectileSpawned);
    // }

    private void OnProjectileSpawned(Projectile projectile)
    {
        if (projectile.TryGetComponent(out IHasDamage damage))
        {
            damage.Damage = damageValue;
        }
    }
}

public interface IHasDamage
{
    public float Damage { get; set; }
}
