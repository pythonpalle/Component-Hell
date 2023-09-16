using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDamageHandler : MonoBehaviour
{
    public DynamicFloat damageValue;
    [SerializeField] private LayerMask layerMask;
    
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
        
        var damageReciever = other.GetComponentInChildren<DamageReciever>();
        if (damageReciever)
        {
            damageReciever.RecieveDamage(damageValue.Value);
            return true;
        } 

        return false;
    }
}
