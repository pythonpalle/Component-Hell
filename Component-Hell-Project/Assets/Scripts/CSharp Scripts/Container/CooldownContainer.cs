using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownContainer : MonoBehaviour
{
    [SerializeField] private FloatVariable cooldownVariable;
    public FloatVariable CooldownVariable => cooldownVariable;

    [SerializeField] private Cooldown _cooldown;

    public Cooldown Cooldown => _cooldown;

    [SerializeField] private bool createInstance;
    private void Awake()
    {
        if (createInstance) cooldownVariable = Instantiate(cooldownVariable);
    }
}
