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
        _healthDataHolder.health = _healthDataHolder.maxHealth.Value;
    }

    private void Start()
    {
        OnHealthStart?.Invoke(_healthDataHolder.health);
    }

    public void TakeDamage(float damage)
    {
        float damageAfterArmour = damage - _healthDataHolder.armour.Value;
        if (damageAfterArmour <= 0)
            return;
        
         _healthDataHolder.health -= damageAfterArmour;
         OnHealthChange?.Invoke(-damageAfterArmour);
        
         if (_healthDataHolder.health <= 0)
         {
             OnDeath?.Invoke();
         }
    }

    public void IncreaseMaxHealth(string fromName, float multiplier, bool resetCurrent)
    {
        _healthDataHolder.maxHealth.AddMultiplier(fromName, multiplier);
        if (resetCurrent) InitializeData();
    }
}
