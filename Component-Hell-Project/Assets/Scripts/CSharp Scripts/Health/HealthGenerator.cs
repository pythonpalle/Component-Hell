using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGenerator : MonoBehaviour
{
    private float timeSinceLastRegenerate;
    private DynamicFloat regenerationAmount;
    private DynamicFloat regenerationSpeed;

    private HealthManager _healthManager;

    private void Awake()
    {
        _healthManager = GetComponent<HealthManager>();
    }

    public void Start()
    {
        regenerationSpeed = _healthManager.DataHolder.regenerationSpeed;
        regenerationAmount = _healthManager.DataHolder.regenerationAmount;
    }

    void Update()
    {
        HandleHealthRegenerate();
    }

    private void HandleHealthRegenerate()
    {
        if (regenerationAmount.Value <= 0)
            return;

        if (_healthManager.IsAtMaxHealth)
        {
            return;
        }

        if (Time.time > regenerationSpeed.Value + timeSinceLastRegenerate)
        {
            _healthManager.Regenerate(regenerationAmount.Value);
            timeSinceLastRegenerate = Time.time;
        }
    }
}
