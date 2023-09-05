using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponController))]
public class ProjectileSpawner : MonoBehaviour
{
    private WeaponController weaponController;
    private ProjectileController projectileControllerInstance;

    private void OnEnable()
    {
        weaponController = GetComponent<WeaponController>();
        
        
        weaponController.OnProjectileFired.AddListener(SpawnProjectile);
        
    }

    private void OnDisable()
    {
        weaponController.OnProjectileFired.RemoveListener(SpawnProjectile);
    }

    public void SpawnProjectile(ProjectileController controller)
    {
        projectileControllerInstance = Instantiate(projectileControllerInstance, transform.position, Quaternion.identity);
        weaponController.OnProjectileFired?.Invoke(projectileControllerInstance);
    }
}
