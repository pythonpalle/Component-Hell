using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Types/Combine")]
public class CombinedUpgrade : UpgradeObject
{
    [SerializeField] private List<UpgradeObject> upgrades;
    public override void Apply(Transform owner)
    {
        foreach (var upgrade in upgrades)
        {
            upgrade.Apply(owner);
        } 
    }
} 