using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHealthDataTransfer : MonoBehaviour, WeaponDataUpdateListener
{
    private HealthManager _healthManager;
    
    void Awake()
    {
        _healthManager = GetComponent<HealthManager>();
    }

    public void OnWeaponDataUpdate(WeaponDataHolder data)
    {
        _healthManager.IncreaseMaxHealth(data.name, data.penetration.Value, true);
    }
}
