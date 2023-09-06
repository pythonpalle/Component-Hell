using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class Cooldown : MonoBehaviour
{
    [SerializeField] private float cooldownTime = 0.5f;
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
        if (Time.time > timeSinceLastCooldown + cooldownTime)
        {
            hasCooledDown = true;
        }
    }
    
}
