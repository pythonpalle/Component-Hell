using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarGUI : MonoBehaviour
{
    // [SerializeField] private FloatVariable playerCurrentHealth;
    // [SerializeField] private FloatVariable playerMaxHealth;
    private Slider slider;

    [SerializeField] private bool connectToCharacterHealthComponent = true;

    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    private float ratio => currentHealth / maxHealth;

    private void OnEnable()
    {
        slider = GetComponent<Slider>();
        slider.value = 1;

        if (connectToCharacterHealthComponent)
            ConnectToCharacterHealth();
    }

    private void ConnectToCharacterHealth() 
    {
        if (!TryFindCharacterHealthComponent(transform, out CharacterHealth health))
            return;
        
        SetMaxHealth(health.MaxHealth);
        health.OnHealthEnable.AddListener(SetMaxHealth);
        health.OnHealthChange.AddListener(OnHealthChange);
    }

    private bool TryFindCharacterHealthComponent(Transform transformToCheck, out CharacterHealth characterHealth)
    {
        if (transformToCheck.TryGetComponent(out characterHealth))
        {
            return true;
        }

        var parentTransform = transformToCheck.parent;
        if (parentTransform == null)
        {
            characterHealth = null;
            return false;
        }

        return TryFindCharacterHealthComponent(parentTransform, out characterHealth);
    }

    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    public void OnHealthChange(float deltaHealth)
    {
        currentHealth += deltaHealth;
        slider.value = ratio;
    }
}
