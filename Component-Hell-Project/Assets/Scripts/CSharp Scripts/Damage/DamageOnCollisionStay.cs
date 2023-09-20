using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private void Start()
    {
        var colliderBroadcaster = MyUtility.TryFindComponentUpwards<ColliderBroadcaster>(transform);
        if (colliderBroadcaster)
        {
            colliderBroadcaster.OnTrigStay.AddListener(TryInflictDamage);
        }
    }

    private void OnDestroy()
    {
        var colliderBroadcaster = MyUtility.TryFindComponentUpwards<ColliderBroadcaster>(transform);
        if (colliderBroadcaster)
        {
            colliderBroadcaster.OnTrigStay.RemoveListener(TryInflictDamage);
        }
    }

    private void TryInflictDamage(Collider2D other)
    {
        if (Time.time > timeBetweenDamageTicks + lastDamageTick && colliderDamageHandler.TryInflictDamage(other))
        {
            lastDamageTick = Time.time;  
        }
    }

    public void TryInflictDamage(Collision2D other)
    {
        if (Time.time > timeBetweenDamageTicks + lastDamageTick && colliderDamageHandler.TryInflictDamage(other))
        {
            lastDamageTick = Time.time;  
        }
    }
    
}