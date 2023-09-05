using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollisionTrigger : MonoBehaviour
{
    [SerializeField] private bool damagePlayer;
    [SerializeField] private bool damageEnemy;

    [SerializeField] private int damageAmount;


    private void OnTriggerEnter2D(Collider2D other)
    {
      Debug.Log($"Collision detected with {other.gameObject.name}!");
    
        if (other.TryGetComponent(out CharacterHealth health))
        {
            health.TakeDamage(damageAmount);
            Debug.Log("Take damage!");
        }
        else
        {
            Debug.Log("No health component found");
        }
        
    }
}
