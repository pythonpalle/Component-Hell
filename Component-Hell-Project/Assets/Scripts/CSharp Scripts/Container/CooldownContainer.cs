using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownContainer : Container
{
    [SerializeField] private FloatVariable cooldownVariable;
    public FloatVariable CooldownVariable => cooldownVariable;

    [SerializeField] private Cooldown _cooldown;

    public Cooldown Cooldown => _cooldown;

    private void Awake()
    {
        if (instantiateScriptableVariables) cooldownVariable = Instantiate(cooldownVariable);
    }
}
