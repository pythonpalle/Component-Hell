using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;

public class FireHandler : MonoBehaviour
{
    private bool isFiring = false;
    [SerializeField] FireType fireType;
    [SerializeField] private bool instantiateFireType;

    public UnityEvent<MonoBehaviour> OnProjectileSpawned;

    private void Awake()
    {
        if (instantiateFireType) fireType = Instantiate(fireType);
    }

    public void TryFire(Projectile projectilePrefab, Weapon owner)
    {
        if (isFiring)
            return;
        
        StartCoroutine(FireRoutine(projectilePrefab, owner));
    }

    private IEnumerator FireRoutine(Projectile projectilePrefab, Weapon owner)
    {
        Debug.Log("Start fire routine!");
        
        isFiring = true;

        var data = owner.Data;
        int amount = (int) data.amount.Value;
        float burstCooldown = data.burstCooldown.Value;
        float shotCooldown = data.shotCooldown.Value;
        
        for (int round = 0; round < amount; round++)
        {
            var projectile = fireType.Fire(data, owner, projectilePrefab, round);
            OnProjectileSpawned?.Invoke(projectile);
            yield return new WaitForSeconds(shotCooldown);
        }

        yield return new WaitForSeconds(burstCooldown);
        isFiring = false;
    }
}




