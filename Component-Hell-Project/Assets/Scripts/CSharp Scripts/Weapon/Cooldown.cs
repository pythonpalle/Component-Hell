using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : GameComponent
{
    private float timeSinceLastCooldown = int.MinValue;
    
    private FloatVariable cooldownTime;

    private void Awake()
    {
        cooldownTime = _metaContainer.CooldownContainer.CooldownVariable;
    }

    private void Update()
    {
        HasCooledDown();
    }

    public void Reset()
    {
        timeSinceLastCooldown = Time.time;
    }

    public bool HasCooledDown()
    {
        return (Time.time > timeSinceLastCooldown + cooldownTime.value);
    }
    
}
