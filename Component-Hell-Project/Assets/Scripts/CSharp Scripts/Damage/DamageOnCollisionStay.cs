using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColliderDamageHandler))]
public class DamageOnCollisionStay : MonoBehaviour
{
    private ColliderDamageHandler colliderDamageHandler;

    [SerializeField] private float timeBetweenDamageTicks = 1f;
    private float lastDamageTick = int.MinValue;

    private void Awake()
    {
        colliderDamageHandler = GetComponent<ColliderDamageHandler>();
    }

    public void TryInflictDamage(Collision2D other)
    {
        if (Time.time > timeBetweenDamageTicks + lastDamageTick && colliderDamageHandler.TryInflictDamage(other.collider))
        {
            lastDamageTick = Time.time;  
        }
    }
    
}