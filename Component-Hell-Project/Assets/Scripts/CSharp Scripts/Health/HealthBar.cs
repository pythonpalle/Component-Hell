using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : GameComponent
{
    private Slider slider;

    [SerializeField] private bool connectToCharacterHealthComponent = true;

    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
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
        CharacterHealth health = _metaContainer.HealthContainer.CharacterCharacterHealth;
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
