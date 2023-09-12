using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTransfer : DataTransfer
{
    [SerializeField] private bool mulitply;
    

    public override void Transfer(GameComponent toComponent)
    {
        float mulitplier = mulitply ? toComponent.MetaContainer.MovementContainer.MovementSpeed.value : 1;

        toComponent.MetaContainer.MovementContainer.MovementSpeed.value = 
            mulitplier * _metaContainer.MovementContainer.MovementSpeed.value;
    }
}
