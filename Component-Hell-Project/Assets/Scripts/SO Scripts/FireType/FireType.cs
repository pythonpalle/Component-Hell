using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireType : ScriptableObject
{
    [SerializeField] protected bool forEachRound;
    [SerializeField] protected bool forEachShotInRound;
    [SerializeField] protected int shotsPerRound = 1;

    public List<Projectile> Fire(WeaponDataHolder data, Weapon owner, Projectile prefab, int round)
    {
        var projectiles = new List<Projectile>();

        for (int i = 0; i < shotsPerRound; i++)
        {
            Vector2 direction = GetDirection(owner, round, i);
            Vector2 position = GetPosition(owner, round, i);
            Projectile instance = Instantiate(prefab, position, Quaternion.identity);
            instance.Create(data, direction);
            projectiles.Add(instance);
        }
        
        return projectiles;
    }

    protected abstract Vector2 GetDirection(Weapon owner, int round, int shotInRound);
    protected virtual Vector2 GetPosition(Weapon owner, int round, int shotInRound) => owner.transform.position;
}