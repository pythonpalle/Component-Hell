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
    
    public bool TryInflictDamage(Collider2D other)
    {
        if ((layerMask.value & (1 << other.gameObject.layer)) > 0 == false)
            return false;
        
        
        if (other.TryGetComponent(out CharacterHealth health))
        {
            health.TakeDamage(damageComponent.currentValue);
            return true;
        }

        return false;
    } 
}
