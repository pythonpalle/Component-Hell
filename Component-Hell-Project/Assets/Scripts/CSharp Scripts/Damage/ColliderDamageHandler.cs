using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageComponent))]
public class ColliderDamageHandler : MonoBehaviour
{
    private DamageComponent damageComponent;
    
    [SerializeField] private bool damagePlayer;
    [SerializeField] private bool damageEnemy;
    
    private void Awake()
    {
        damageComponent = GetComponent<DamageComponent>();
    }
    
    public void HandleDamage(Collider2D other)
    {
        if (other.TryGetComponent(out CharacterHealth health))
        {
            // TODO: Ändra till layers
            if (other.gameObject.CompareTag("Player") && damagePlayer
                || other.gameObject.CompareTag("Enemy") && damageEnemy)
            {
                health.TakeDamage(damageComponent.currentValue);
            }
        }
    }
}
