using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterHealth : MonoBehaviour
{
    public UnityEvent<float> OnHealthEnable;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnDeath;

    private HealthDataHolder _healthDataHolder;

    private void Awake()
    {
        _healthDataHolder = GetComponent<HealthManager>().HealthDataHolder;
    }

    private void Start()
    {
        // healthVariable = _metaContainer.HealthContainer.ValueWrapper.CurrentValue;
        // healthVariable.value = _metaContainer.HealthContainer.MaxHealthWrapper.CurrentValue.value;
        //
        // OnHealthEnable?.Invoke(_metaContainer.HealthContainer.MaxHealthWrapper.CurrentValue.value);
    }

    public void TakeDamage(float damage)
    {
        //_healthDataHolder.health.Value -= damage;
        // OnHealthChange?.Invoke(-damage);
        //
        // if (healthVariable.value <= 0)
        // {
        //     OnDeath?.Invoke();
        // }
    }
}
