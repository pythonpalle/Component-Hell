using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstWeaponFire : WeaponFireType
{
    [SerializeField] private int burstCount = 3;
    [SerializeField] private float timeBetweenBursts = 0.3f;

    private bool routineIsRunning = false;

    public override void Fire(Projectile projectile, Weapon weapon)
    {
        if (!routineIsRunning)
        {
            StartCoroutine(Burst( projectile, weapon));
        }
    }

    IEnumerator Burst(Projectile projectile,  Weapon weapon)
    {
        routineIsRunning = true;
        
        for (int i = 0; i < burstCount; i++)
        {
            SpawnProjectile(projectile);
            SetupProjectile(projectile, weapon);
            Debug.Log("Phew!");

            yield return new WaitForSeconds(timeBetweenBursts);
        }

        routineIsRunning = false;
    }
}
