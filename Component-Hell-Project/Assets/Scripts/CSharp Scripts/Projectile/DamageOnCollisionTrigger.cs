using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColliderDamageHandler))]
public class DamageOnCollisionTrigger : MonoBehaviour
{
    private ColliderDamageHandler colliderDamageHandler;

    private void Awake()
    {
        colliderDamageHandler = GetComponent<ColliderDamageHandler>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        colliderDamageHandler.TryInflictDamage(other);
    }

}
