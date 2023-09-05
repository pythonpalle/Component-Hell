using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponController))]
public class WeaponDamage : MonoBehaviour, IHasDamage
{
    private WeaponController weapon;
    [SerializeField] private float damageValue = 1;
    
    private void OnEnable()
    {
        weapon = GetComponent<WeaponController>();
        
        weapon.OnProjectileSpawned.AddListener(OnProjectileSpawned);
    }
    
    private void OnDisable()
    {
        weapon.OnProjectileSpawned.RemoveListener(OnProjectileSpawned);
    }

    private void OnProjectileSpawned(ProjectileController projectile)
    {
        if (projectile.TryGetComponent(out IHasDamage damage))
        {
            damage.Damage = damageValue;
        }
    }

    // Update is called once per frame
    void Update() 
    {
         
    }

    public float Damage { get; set; }
    public void SetDamage(float value)
    {
        Damage = value;
    }
}

public interface IHasDamage
{
    public float Damage { get; set; }

    public void SetDamage(float value);
}
