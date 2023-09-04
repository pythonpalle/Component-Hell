using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterHealth : MonoBehaviour
{
    public UnityEvent<float> OnHealthEnable;
    public UnityEvent<float> OnDamage;
    public UnityEvent OnDeath;
    
    [SerializeField] private float maxHealth;
    public float MaxHealth => maxHealth;
    
    public float CurrentHealth { get; private set; }

    private void OnEnable()
    {
        OnHealthEnable?.Invoke(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        OnDamage?.Invoke(damage);

        if (CurrentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
