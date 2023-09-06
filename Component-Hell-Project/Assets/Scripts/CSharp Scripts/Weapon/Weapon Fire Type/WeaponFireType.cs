using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class WeaponFireType : MonoBehaviour
{
    public abstract void Fire(Projectile projectile);

    protected void SpawnProjectile(Projectile projectile)
    {
        Instantiate(projectile, transform.position, quaternion.identity);
    }
}
