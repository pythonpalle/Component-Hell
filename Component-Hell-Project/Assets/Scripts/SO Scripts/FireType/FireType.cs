using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireType : ScriptableObject
{
    public Projectile Fire(WeaponDataHolder data, Weapon owner, Projectile prefab, int round)
    {
        Vector2 direction = GetDirection(owner, round);
        Vector2 position = GetPosition(owner, round);
        
        Projectile instance = Instantiate(prefab, position, Quaternion.identity);
        instance.OnCreated?.Invoke(data, direction);
        return instance;
    }

    protected abstract Vector2 GetDirection(Weapon owner, int round);
    protected abstract Vector2 GetPosition(Weapon owner, int round);
}
