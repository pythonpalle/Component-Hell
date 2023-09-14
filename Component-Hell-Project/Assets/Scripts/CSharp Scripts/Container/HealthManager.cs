using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private HealthDataHolder _healthDataHolder;
    
    [SerializeField] bool instantiateScriptableObjects = true;
    
    [Header("Events")]
    public UnityEvent<float> OnHealthStart;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnDeath;

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

    private void Start()
    {
        OnHealthStart?.Invoke(_healthDataHolder.health.Value);
    }

    public void TakeDamage(float damage)
    {
        float damageAfterArmour = damage - _healthDataHolder.armour.Value;
        if (damageAfterArmour <= 0)
            return;
        
        _healthDataHolder.health.Add(-damageAfterArmour);
         OnHealthChange?.Invoke(-damageAfterArmour);
        
         if (_healthDataHolder.health.Value <= 0)
         {
             OnDeath?.Invoke();
         }
    }
}
