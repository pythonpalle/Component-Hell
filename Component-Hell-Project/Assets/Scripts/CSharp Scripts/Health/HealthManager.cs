using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
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

    private float prevMaxHealth;
    public bool IsAtMaxHealth => _healthDataHolder.health >= _healthDataHolder.maxHealth.Value;
    public float MaxHealth => _healthDataHolder.maxHealth.Value;
    public float CurrentHealth => _healthDataHolder.health;

    void Awake()
    {
        if (instantiateScriptableObjects)
        {
            _healthDataHolder = Instantiate(_healthDataHolder);
        }
        
        InitializeData();
    }
    
    private void Start()
    {
        GameUpgradeManager.Instance.OnUpgrade.AddListener(OnUpgrade);
        
        OnSetMaxHealth?.Invoke(_healthDataHolder.maxHealth.Value);
        OnHealthChange?.Invoke(_healthDataHolder.health);
    }

    private void OnDestroy()
    {
        GameUpgradeManager.Instance.OnUpgrade.RemoveListener(OnUpgrade);
    }

    public void OnUpgrade(UpgradeManager manager)
    {
        if (manager.ManagerType == UpgradeMangerType.Health)
        {
            DetectMaxhHealthChange();
        }
    }

    
    private void InitializeData()
    {
        _healthDataHolder.health = _healthDataHolder.maxHealth.Value;
        prevMaxHealth = _healthDataHolder.maxHealth.Value;
    }

    

    public void Regenerate(float deltaHealth)
    {
        float toRegen = LimitRegenerationAtMax(deltaHealth);
        if (toRegen <= 0)
            return; 
        
        ChangeHealth(toRegen);
    }
    
    private float LimitRegenerationAtMax(float deltaHealth)
    {
        float differenceToMax = MaxHealth - CurrentHealth;

        float toRegenerate = differenceToMax < deltaHealth ? differenceToMax : deltaHealth;
        return toRegenerate;
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
        else if (IsAtMaxHealth)
        {
            _healthDataHolder.health = _healthDataHolder.maxHealth.Value;
        }
    }

    public void IncreaseMaxHealth(string fromName, float multiplier, bool resetCurrent)
    {
        _healthDataHolder.maxHealth.AddMultiplier(fromName, multiplier);
        if (resetCurrent) InitializeData();
    }
    

    private void DetectMaxhHealthChange()
    {
        if (Mathf.Abs(_healthDataHolder.maxHealth.Value - prevMaxHealth) > 0.0001f)
        {
            OnSetMaxHealth?.Invoke(_healthDataHolder.maxHealth.Value);
            prevMaxHealth = _healthDataHolder.maxHealth.Value;
        }
    }
}
