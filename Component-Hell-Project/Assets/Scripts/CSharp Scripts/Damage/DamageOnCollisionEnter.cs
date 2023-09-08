using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColliderDamageHandler))]
public class DamageOnCollisionEnter : MonoBehaviour
{
    private ColliderDamageHandler colliderDamageHandler;

    private void Awake()
    {
        colliderDamageHandler = GetComponent<ColliderDamageHandler>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        colliderDamageHandler.TryInflictDamage(other.collider);
    }
}
