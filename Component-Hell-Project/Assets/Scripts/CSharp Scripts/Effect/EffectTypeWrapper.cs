using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EffectTypeWrapper
{
    public EffectType Type;

    public EffectTypeWrapper(EffectType effectType)
    {
        Type = effectType;
    }
}
