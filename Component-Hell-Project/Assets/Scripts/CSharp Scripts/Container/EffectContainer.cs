using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectContainer : Container
{
    [SerializeField] private FloatVariable effectTimeVariable;

    public FloatVariable EffectTimeVariable => effectTimeVariable;
    
    public List<EffectComponent> activeEffects = new List<EffectComponent>();

    private void Awake() 
    {
        if (instantiateScriptableVariables && effectTimeVariable) effectTimeVariable = Instantiate(effectTimeVariable);
    }
}
