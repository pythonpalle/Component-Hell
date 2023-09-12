using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownTransfer : DataTransfer
{
    public override void Transfer(GameComponent toComponent)
    {
        float otherValue = toComponent.MetaContainer.CooldownContainer.CooldownVariable.value;
        float thisValue = _metaContainer.CooldownContainer.CooldownVariable.value;

        toComponent.MetaContainer.CooldownContainer.CooldownVariable.value =
            Multiplier(otherValue) * thisValue;
    }
}
