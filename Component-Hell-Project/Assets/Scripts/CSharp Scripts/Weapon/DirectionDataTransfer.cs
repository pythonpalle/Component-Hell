using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDataTransfer : DataTransfer
{
    public override void Transfer(GameComponent toComponent)
    {
        toComponent.MetaContainer.MovementContainer.DirectionVariable.value =
            _metaContainer.MovementContainer.DirectionVariable.value; 
    }

}
