using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTransfer : DataTransfer
{
    public override void Transfer(GameComponent toComponent)
    {
        toComponent.MetaContainer.DamageContainer.DamageVariable.value =
            Multiplier(toComponent.MetaContainer.DamageContainer.DamageVariable.value) *
            _metaContainer.DamageContainer.DamageVariable.value;
    }
}
