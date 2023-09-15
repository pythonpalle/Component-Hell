using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class FireHandler : MonoBehaviour
{
    public bool isFiring { get; private set; } = false;
    public FireType fireType;

    public void TryFire(Projectile projectilePrefab, WeaponDataHolder data)
    {
        if (isFiring)
            return;
        
        StartCoroutine(FireRoutine(projectilePrefab, data));
    }

    private IEnumerator FireRoutine(Projectile projectilePrefab, WeaponDataHolder data)
    {
        isFiring = true;

        int amount = (int) data.amount.Value;
        float burstCooldown = data.burstCooldown.Value;
        float shotCooldown = data.shotCooldown.Value;
        
        for (int round = 0; round < amount; round++)
        {
            fireType.Fire(data, this, projectilePrefab, round);
            yield return new WaitForSeconds(shotCooldown);
        }
        
        
        yield return new WaitForSeconds(burstCooldown);
        isFiring = false;
    }

    protected Projectile SpawnProjectile(Projectile projectile, Weapon weapon)
    {
        var instance = Instantiate(projectile, transform.position, quaternion.identity);
        weapon.OnProjectileSpawned?.Invoke(instance);
        return instance;
    }
}

public abstract class FireType : ScriptableObject
{
    public void Fire(WeaponDataHolder data, FireHandler handler, Projectile prefab, int round)
    {
        Vector2 direction = GetDirection(handler, round);
        Vector2 position = GetPosition(handler, round);
        
        Projectile instance = Instantiate(prefab, position, Quaternion.identity);
        instance.OnCreated?.Invoke(data, direction);
    }

    protected abstract Vector2 GetPosition(FireHandler handler, int round);
    protected abstract Vector2 GetDirection(FireHandler handler, int round);
}

public class DirectionalFire : FireType
{
    protected override Vector2 GetPosition(FireHandler handler, int round)
    {
        throw new System.NotImplementedException();
    }

    protected override Vector2 GetDirection(FireHandler handler, int round)
    {
        throw new System.NotImplementedException();
    }
}
