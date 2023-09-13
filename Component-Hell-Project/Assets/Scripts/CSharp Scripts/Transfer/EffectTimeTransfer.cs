using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTimeTransfer : DataTransfer
{
    public override void Transfer(GameComponent toComponent)
    {
        var fromWrapper = _metaContainer.EffectContainer.ValueWrapper;
        var toWrapper = toComponent.MetaContainer.EffectContainer.ValueWrapper;
        
        TransferFloatData(fromWrapper, toWrapper);
    }
}
