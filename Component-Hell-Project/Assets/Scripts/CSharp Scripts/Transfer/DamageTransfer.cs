using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTransfer : DataTransfer
{
    public override void Transfer(GameComponent toComponent)
    {
        var fromWrapper = _metaContainer.DamageContainer.ValueWrapper;
        var toWrapper = toComponent.MetaContainer.DamageContainer.ValueWrapper;
        
        TransferFloatData(fromWrapper, toWrapper);
    }
}
