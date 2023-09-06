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

    private void OnCollisionStay2D(Collision2D other)
    {
        if (Time.time > timeBetweenDamageTicks + lastDamageTick)
        {
            colliderDamageHandler.HandleDamage(other.collider);
            lastDamageTick = Time.time;
        }
        
    }
}