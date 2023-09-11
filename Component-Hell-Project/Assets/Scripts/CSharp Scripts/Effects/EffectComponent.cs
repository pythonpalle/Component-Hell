using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectComponent : GameComponent
{
    public float duration = 1;

    public virtual void OnInstantiated(float effectTimeValue)
    {
        duration *= effectTimeValue;
    }
}
