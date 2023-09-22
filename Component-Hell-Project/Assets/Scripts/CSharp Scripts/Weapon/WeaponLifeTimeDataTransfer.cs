using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroyAfterSeconds))]
public class WeaponLifeTimeDataTransfer : MonoBehaviour, IWeaponDataUpdateListener
{
    public void OnWeaponDataUpdate(WeaponDataHolder data)
    {
        GetComponent<DestroyAfterSeconds>().SetLifeTime(data.lifeTime.Value);
    }
}
