using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider slider;

    [SerializeField] private bool connectToCharacterHealthComponent = true;

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    private float ratio => (float)currentHealth / maxHealth;

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

    /*
     * Looks for a component T on the existing gameobject by searching upwards to the parent node
     */
    private bool TryFindCharacterHealthComponent(Transform transformToCheck, out CharacterHealth characterHealth)
    {

        characterHealth = transformToCheck.GetComponentInChildren<CharacterHealth>();
        if (characterHealth)
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

    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    public void OnHealthChange(int deltaHealth)
    {
        currentHealth += deltaHealth;
        slider.value = ratio;
    }
}
