using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownContainer : Container
{
    [SerializeField] private Cooldown _cooldown;

    public Cooldown Cooldown => _cooldown;
}
