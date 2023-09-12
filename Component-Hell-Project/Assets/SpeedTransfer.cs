using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTransfer : DataTransfer
{
    
    public override void Transfer(GameComponent toComponent)
    {
        var toSpeed = toComponent.MetaContainer.MovementContainer.MovementSpeed.value;

        toComponent.MetaContainer.MovementContainer.MovementSpeed.value = 
            Multiplier(toSpeed) * _metaContainer.MovementContainer.MovementSpeed.value;
    }
}
