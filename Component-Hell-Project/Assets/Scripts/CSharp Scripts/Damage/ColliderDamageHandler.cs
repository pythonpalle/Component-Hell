using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDamageHandler : GameComponent
{
    private FloatVariable damageValue;
    
    [SerializeField] private LayerMask layerMask;
    
    private void Start()
    {
        damageValue = _metaContainer.DamageContainer.ValueWrapper.CurrentValue;
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
        
        Debug.Log("Try inflict damage");
        if ((layerMask.value & (1 << other.gameObject.layer)) > 0 == false)
            return false;

        var health = other.GetComponentInChildren<CharacterHealth>();
        if (health)
        {
            health.TakeDamage(damageValue.value);
            Debug.Log("Take damage!");
            return true;
        } 

        return false;
    }
}
