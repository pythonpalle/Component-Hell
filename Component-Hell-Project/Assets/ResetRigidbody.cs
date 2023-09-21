using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRigidbody : MonoBehaviour
{
    Rigidbody2D rb;
    
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("ResetVelocity", 0f, 1f);
    }

    private void ResetVelocity()
    {
        rb.velocity = Vector2.zero;
    }
}
