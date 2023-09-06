using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstWeaponFire : WeaponFireType
{
    [SerializeField] private int burstCount = 3;
    [SerializeField] private float timeBetweenBursts = 0.3f;

    private bool routineIsRunning = false;

    public override void Fire(Projectile projectile)
    {
        if (!routineIsRunning)
        {
            StartCoroutine(Burst(projectile));
        }
    }

    IEnumerator Burst(Projectile projectile)
    {
        routineIsRunning = true;

        for (int i = 0; i < burstCount; i++)
        {
            SpawnProjectile(projectile);
            yield return new WaitForSeconds(timeBetweenBursts);
        }

        routineIsRunning = false;
    }
}
