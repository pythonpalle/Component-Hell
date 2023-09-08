using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownOnImpact : MonoBehaviour
{
    public float effectTime = 2f;
    public float speedModifier = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SpeedComponent speedComponent = other.GetComponentInChildren<SpeedComponent>();
        
        if (speedComponent)
        {
            speedComponent.currentValue *= speedModifier;
            Destroy(this, effectTime); 
        }
    }
}
