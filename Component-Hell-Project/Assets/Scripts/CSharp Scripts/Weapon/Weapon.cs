using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour
{
    // public UnityEvent OnCooldownComplete;
    //
    // public UnityEvent<ProjectileController> OnProjectileFired;
    // //public UnityEvent<ProjectileController> OnProjectileSpawned;

    [SerializeField] private Projectile projectile;
    [SerializeField] private WeaponFireType fireType;
    [SerializeField] private WeaponController controller;
    [SerializeField] private SpeedComponent speed;
    [SerializeField] private DirectionComponent direction;
    [SerializeField] private Cooldown cooldown;
    

    private void Update()
    {
        HandleShooting();
    }

    private void HandleShooting()
    {
        bool wantsToShoot = !controller || controller.WantsToShoot();
        bool hasCooledDown = !cooldown || cooldown.hasCooledDown;
        
        if (wantsToShoot && hasCooledDown)
        {
            SetupProjectile();
            
            fireType.Fire(projectile);
            cooldown.Reset();
            
        }
    }

    void SetupProjectile()
    {
        
    }

    //public ProjectileController projectileController;
   
    // [SerializeField] private float cooldown = 5f;
    // // [SerializeField] private int damage = 1;
    // // [SerializeField] private Vector2 direction;
    //
    //
    // private float timeSinceLastFire = int.MinValue;
    //

    // // Update is called once per frame
    // void Update()
    // {
    //     HandleProjectileFire();
    // }
    //
    // private void HandleProjectileFire()
    // {
    //     if (Time.time > timeSinceLastFire + cooldown)
    //     {
    //         OnProjectileFired?.Invoke(projectileController);
    //         //var projectileInstance = Instantiate(projectileController, transform.position, Quaternion.identity);
    //         timeSinceLastFire = Time.time;
    //     }
    // }
}
