using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : FloatValueComponent
{
    private float timeSinceLastCooldown = int.MinValue;
    public bool hasCooledDown { get; private set; } = true;
    

    private void Update()
    {
        UpdateCooldown();
    }

    public void Reset()
    {
        hasCooledDown = false;
        timeSinceLastCooldown = Time.time;
    }

    private void UpdateCooldown()
    {
        if (Time.time > timeSinceLastCooldown + currentValue)
        {
            hasCooledDown = true;
        }
    }
    
}
