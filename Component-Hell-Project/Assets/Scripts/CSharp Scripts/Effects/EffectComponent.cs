using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectComponent : MonoBehaviour
{
    public float duration = 1;

    // public virtual void OnInstantiated(float effectTimeValue)
    // {
    //     duration *= effectTimeValue;
    //     _metaContainer.EffectContainer.activeEffects.Add(this);
    // }
    //
    // protected virtual void OnDestroy()
    // {
    //     _metaContainer.EffectContainer.activeEffects.Remove(this);
    // }
}
