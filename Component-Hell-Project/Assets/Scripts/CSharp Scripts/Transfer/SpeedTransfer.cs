using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTransfer : DataTransfer
{
    public override void Transfer(GameComponent toComponent)
    {
        var fromWrapper = _metaContainer.MovementContainer.ValueWrapper;
        var toWrapper = toComponent.MetaContainer.MovementContainer.ValueWrapper;
        
        TransferFloatData(fromWrapper, toWrapper);
    }
}
