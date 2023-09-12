using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTimeTransfer : DataTransfer
{
    public override void Transfer(GameComponent toComponent)
    {
        toComponent.MetaContainer.EffectContainer.EffectTimeVariable.value *=
            Multiplier(toComponent.MetaContainer.EffectContainer.EffectTimeVariable.value) *
            _metaContainer.EffectContainer.EffectTimeVariable.value;
    }
}
