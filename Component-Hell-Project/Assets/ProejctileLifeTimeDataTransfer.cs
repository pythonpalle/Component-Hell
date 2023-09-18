using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroyAfterSeconds))]
public class ProejctileLifeTimeDataTransfer : MonoBehaviour, IProjectileSpawnListener
{
    public void OnProjectileSpawn(WeaponDataHolder data, Vector2 direction)
    {
        GetComponent<DestroyAfterSeconds>().SetLifeTime(data.lifeTime.Value);
    }
}
