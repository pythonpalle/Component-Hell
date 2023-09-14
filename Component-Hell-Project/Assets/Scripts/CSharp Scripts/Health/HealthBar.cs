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
        _healthManager.OnHealthStart.AddListener(SetMaxHealth);
        _healthManager.OnHealthChange.AddListener(OnHealthChange);
    }

    // /*
    //  * Looks for a component T on the existing gameobject by searching upwards to the parent node
    //  */
    // private bool TryFindCharacterHealthComponent(Transform transformToCheck, out CharacterHealth characterHealth)
    // {
    //
    //     characterHealth = transformToCheck.GetComponentInChildren<CharacterHealth>();
    //     if (characterHealth)
    //     {
    //         return true;
    //     }
    //
    //     var parentTransform = transformToCheck.parent;
    //     if (parentTransform == null)
    //     {
    //         characterHealth = null;
    //         return false;
    //     }
    //
    //     return TryFindCharacterHealthComponent(parentTransform, out characterHealth);
    // }

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
