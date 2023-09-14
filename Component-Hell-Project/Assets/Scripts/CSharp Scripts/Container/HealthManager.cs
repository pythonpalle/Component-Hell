using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private HealthDataHolder _healthDataHolder;
    public HealthDataHolder HealthDataHolder => _healthDataHolder;
    
    [SerializeField] bool instantiateScriptableObjects = true;

    void Awake()
    {
        if (instantiateScriptableObjects)
        {
            _healthDataHolder = Instantiate(_healthDataHolder);
        }

        InitializeData();
    }

    private void InitializeData()
    {
        _healthDataHolder.health = _healthDataHolder.maxHealth;
    }
}
