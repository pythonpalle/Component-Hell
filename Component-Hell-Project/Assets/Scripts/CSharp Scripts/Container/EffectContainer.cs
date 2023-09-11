using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectContainer : Container
{
    [SerializeField] private EffectTimeComponent effectTimeComponent;

    public EffectTimeComponent EffectTimeComponent => effectTimeComponent;
    
    public List<EffectComponent> activeEffects = new List<EffectComponent>();

}
