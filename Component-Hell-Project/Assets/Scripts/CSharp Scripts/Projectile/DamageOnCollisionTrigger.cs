using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollisionTrigger : MonoBehaviour, IHasDamage
{
    [SerializeField] private bool damagePlayer;
    [SerializeField] private bool damageEnemy;

    [SerializeField] private int damageAmount;
    
    public float Damage { get; set; }

    private void OnEnable()
    {
        Damage = damageAmount;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
      Debug.Log($"Collision detected with {other.gameObject.name}!");
    
        if (other.TryGetComponent(out CharacterHealth health))
        {
            if (health.gameObject.CompareTag("Player") && damagePlayer)
            {
                health.TakeDamage((int)Damage);
                Debug.Log("Player Take damage!");
            }
            
            if (health.gameObject.CompareTag("Enemy") && damageEnemy)
            {
                health.TakeDamage((int)Damage);
                Debug.Log("Enemy Take damage!");
            }
            
        }
        else
        {
            Debug.Log("No health component found");
        }
        
    }

}
