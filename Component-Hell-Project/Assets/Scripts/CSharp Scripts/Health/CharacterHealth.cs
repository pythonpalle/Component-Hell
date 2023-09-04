using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    public float MaxHealth => maxHealth;
    

    public float CurrentHealth { get; private set; }
    private bool isAlive = true;

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            HandleDeath();
        }
    }

    private void HandleDeath()
    {
        isAlive = false;
        
    }
}
