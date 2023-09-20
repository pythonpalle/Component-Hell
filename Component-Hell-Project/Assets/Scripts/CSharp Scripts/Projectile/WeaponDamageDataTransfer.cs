using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamageDataTransfer : MonoBehaviour, WeaponDataUpdateListener
{
    private ColliderDamageHandler _damageHandler;
    
    private void Awake()
    {
        _damageHandler = GetComponent<ColliderDamageHandler>();
    }

    public void OnWeaponDataUpdate(WeaponDataHolder data)
    {
        _damageHandler.damageValue.AddMultiplier(data.name, data.attackDamage.Value);
    }
}
