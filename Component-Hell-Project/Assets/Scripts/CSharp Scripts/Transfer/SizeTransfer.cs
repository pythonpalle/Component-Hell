using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeTransfer : DataTransfer
{
    public override void Transfer(GameComponent toComponent)
    {
        var fromWrapper = _metaContainer.SizeContainer.ValueWrapper;
        var toWrapper = toComponent.MetaContainer.SizeContainer.ValueWrapper;
        
        TransferFloatData(fromWrapper, toWrapper);
    }
}
