using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SingleWeaponFire : WeaponFireType
{
    public override void Fire(Projectile projectile)
    {
        SpawnProjectile(projectile);
    }
} 
