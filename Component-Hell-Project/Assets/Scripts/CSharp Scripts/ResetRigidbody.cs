using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRigidbody : MonoBehaviour
{
    public Rigidbody2D rb;
    
    private float lastTimeOfReset;
    private float timeBetweenChecks = 2f;
    
    void OnEnable()
    {
        if (!rb)
            rb = MyUtility.TryFindComponentUpwards<Rigidbody2D>(transform);
        
        ResetVelocity();
    }

    public void HandleReset(float timeUntilReset)
    {
        Invoke("ResetVelocity", timeUntilReset);
    }

    private void Update()
    {
        if (Time.time > lastTimeOfReset + timeBetweenChecks)
        {
            ResetVelocity();
        }
    }

    private void ResetVelocity()
    {
        if (rb)
        {
            //rb.velocity = Vector2.zero;
            lastTimeOfReset = Time.time;
        }
    }
}
