using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageComponent))]
public class ColliderDamageHandler : MonoBehaviour
{
    private DamageComponent damageComponent;
    
    [SerializeField] private LayerMask layerMask;
    
    private void Awake()
    {
        damageComponent = GetComponent<DamageComponent>();
    }
    
    public void CallTryInflictDamage(Collision2D other)
    {
        TryInflictDamage(other);
    }
    
    public void CallTryInflictDamage(Collider2D other)
    {
        TryInflictDamage(other);
    }
    
    public bool TryInflictDamage(Collision2D other)
    {
         return TryInflictDamage(other.collider);
    }

    public bool TryInflictDamage(Collider2D other)
    {
        if ((layerMask.value & (1 << other.gameObject.layer)) > 0 == false)
            return false;

        var health = other.GetComponentInChildren<CharacterHealth>();
        if (health)
        {
            health.TakeDamage(damageComponent.currentValue);
            return true;
        } 

        return false;
    }
}
