using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public abstract class WeaponFireType : MonoBehaviour
{
    public abstract void Fire(Projectile projectile, Weapon weapon);

    protected void SpawnProjectile(Projectile projectile, Weapon weapon)
    {
        var instance = Instantiate(projectile, transform.position, quaternion.identity);
        weapon.OnProjectileSpawned?.Invoke(instance);
    }

    protected void SetupProjectile(Projectile projectile, Weapon weapon)
    {
        projectile.SetUp(weapon);
    }
}
