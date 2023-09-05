using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterHealth : MonoBehaviour
{
    public UnityEvent<int> OnHealthEnable;
    public UnityEvent<int> OnHealthChange;
    public UnityEvent OnDeath;

    [SerializeField] private int maxHealth = 10;
    public int MaxHealth => maxHealth;

    public int CurrentHealth { get; private set; }

    private void OnEnable()
    {
        OnHealthEnable?.Invoke(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        OnHealthChange?.Invoke(-damage);

        if (CurrentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
