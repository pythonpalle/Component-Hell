using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownTransfer : DataTransfer
{
    public override void Transfer(GameComponent toComponent)
    {
        var fromWrapper = _metaContainer.CooldownContainer.ValueWrapper;
        var toWrapper = toComponent.MetaContainer.CooldownContainer.ValueWrapper;
        
        TransferFloatData(fromWrapper, toWrapper);
    }
}
