using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class ProjectileSpawner : MonoBehaviour
{
    private Weapon _weapon;

    // private void OnEnable()
    // {
    //     _weapon = GetComponent<Weapon>();
    //     
    //     //weaponController.OnProjectileFired.AddListener(SpawnProjectile);
    //     _weapon.OnCooldownComplete.AddListener(SpawnProjectile);
    // }

    // private void OnDisable()
    // {
    //     //weaponController.OnProjectileFired.RemoveListener(SpawnProjectile);
    //     _weapon.OnCooldownComplete.AddListener(SpawnProjectile);
    // }
    //
    // // public void SpawnProjectile(ProjectileController controller)
    // // {
    // //     projectileControllerInstance = Instantiate(projectileControllerInstance, transform.position, Quaternion.identity);
    // //     weaponController.OnProjectileFired?.Invoke(projectileControllerInstance);
    // // }
    //
    // public void SpawnProjectile()
    // {
    //     var projectileControllerInstance = Instantiate(_weapon.projectileController, transform.position, Quaternion.identity);
    //     _weapon.OnProjectileFired?.Invoke(projectileControllerInstance);
    // }
}
