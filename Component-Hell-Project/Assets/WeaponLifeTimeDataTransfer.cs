using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroyAfterSeconds))]
public class WeaponLifeTimeDataTransfer : MonoBehaviour, WeaponDataUpdateListener
{
    public void OnWeaponDataUpdate(WeaponDataHolder data)
    {
        GetComponent<DestroyAfterSeconds>().SetLifeTime(data.lifeTime.Value);
    }
}
