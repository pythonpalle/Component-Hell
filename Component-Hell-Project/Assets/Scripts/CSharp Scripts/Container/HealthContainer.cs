using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthContainer : MonoBehaviour
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
    }
}
