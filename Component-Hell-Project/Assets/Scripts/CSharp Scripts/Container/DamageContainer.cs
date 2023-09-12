using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageContainer : Container
{
    [SerializeField] private FloatVariable damageVariable;

    public FloatVariable DamageVariable => damageVariable;

    private void Awake()
    {
        if (instantiateScriptableVariables) damageVariable = Instantiate(damageVariable);
    }
}
