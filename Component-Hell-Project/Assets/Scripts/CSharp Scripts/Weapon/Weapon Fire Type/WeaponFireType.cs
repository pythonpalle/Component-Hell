using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public abstract class WeaponFireType : MonoBehaviour
{
    public abstract void Fire(Projectile projectile, Weapon weapon);

    protected void SpawnProjectile(Projectile projectile)
    {
        Instantiate(projectile, transform.position, quaternion.identity);
    }

    protected void SetupProjectile(Projectile projectile, Weapon weapon)
    {
        projectile.SetUp(weapon);
    }
}
