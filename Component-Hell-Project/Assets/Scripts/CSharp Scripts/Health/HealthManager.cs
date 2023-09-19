using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private HealthDataHolder _healthDataHolder;
    public HealthDataHolder DataHolder => _healthDataHolder;

    [SerializeField] bool instantiateScriptableObjects = true;
    
    [Header("Events")]
    public UnityEvent<float> OnSetMaxHealth;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnDeath;

    [Header("Regenerate")]
    private float timeSinceLastRegenerate;
    private DynamicFloat regenerationAmount;
    private DynamicFloat regenerationSpeed;
    [SerializeField] private float timeBetweenRegenates = 3f;

    private float prevMaxHealth;

    void Awake()
    {
        if (instantiateScriptableObjects)
        {
            _healthDataHolder = Instantiate(_healthDataHolder);
        }
        
        InitializeData();
    }

    private bool isAtMaxHealth => _healthDataHolder.health >= _healthDataHolder.maxHealth.Value;
    
    private void InitializeData()
    {
        _healthDataHolder.health = _healthDataHolder.maxHealth.Value;
        prevMaxHealth = _healthDataHolder.maxHealth.Value;
    }

    private void Start()
    {
        OnSetMaxHealth?.Invoke(_healthDataHolder.maxHealth.Value);
        OnHealthChange?.Invoke(_healthDataHolder.health);
        
        regenerationSpeed = _healthDataHolder.regenerationSpeed;
        regenerationAmount = _healthDataHolder.regenerationAmount;
    }

    public void TakeDamage(float damage)
    {
        float damageAfterArmour = damage - _healthDataHolder.armour.Value;
        if (damageAfterArmour <= 0)
            return;
        
        ChangeHealth(-damageAfterArmour); 
         
    }

    private void ChangeHealth(float deltaHealth)
    {
        _healthDataHolder.health += deltaHealth;
        OnHealthChange?.Invoke(deltaHealth);
        
        if (_healthDataHolder.health <= 0)
        {
            OnDeath?.Invoke();
        }
        else if (isAtMaxHealth)
        {
            _healthDataHolder.health = _healthDataHolder.maxHealth.Value;
        }
    }

    public void IncreaseMaxHealth(string fromName, float multiplier, bool resetCurrent)
    {
        _healthDataHolder.maxHealth.AddMultiplier(fromName, multiplier);
        if (resetCurrent) InitializeData();
    }

    private void Update()
    {
        DetectMaxhHealthChange();
        HandleHealthGenerate();
    }

    private void DetectMaxhHealthChange()
    {
        if (Mathf.Abs(_healthDataHolder.maxHealth.Value - prevMaxHealth) > 0.0001f)
        {
            OnSetMaxHealth?.Invoke(_healthDataHolder.maxHealth.Value);
            prevMaxHealth = _healthDataHolder.maxHealth.Value;
        }
    }

    private void HandleHealthGenerate()
    {
        if (regenerationAmount.Value <= 0)
            return;

        if (isAtMaxHealth)
        {
            _healthDataHolder.health = _healthDataHolder.maxHealth.Value;
            return;
        }

        if (Time.time > regenerationSpeed.Value + timeSinceLastRegenerate)
        {
            ChangeHealth(regenerationAmount.Value);
            timeSinceLastRegenerate = Time.time;
        }
    }
}
