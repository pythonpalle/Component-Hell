using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider slider;

    [SerializeField] private HealthManager _healthManager;

    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    private float ratio => (float)currentHealth / maxHealth;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = 1;

        ConnectToCharacterHealth();
    }

    private void ConnectToCharacterHealth()
    {
        _healthManager.OnSetMaxHealth.AddListener(SetMaxHealth);
        _healthManager.OnHealthChange.AddListener(OnHealthChange);
    }

    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public void OnHealthChange(float deltaHealth)
    {
        currentHealth += deltaHealth;
        slider.value = ratio;
    }
}
