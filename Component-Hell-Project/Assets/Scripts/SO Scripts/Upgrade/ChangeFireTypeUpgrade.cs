using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Types/FireType")]
public class ChangeFireTypeUpgrade : UpgradeObject
{
    [SerializeField] private FireType fireType;

    public override void Apply(Transform owner)
    {
        var fireHandler = owner.GetComponent<FireHandler>();
        fireHandler.ChangeFireType(fireType);
    }
}
