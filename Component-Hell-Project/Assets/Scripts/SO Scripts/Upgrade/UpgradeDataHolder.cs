using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/UpgradeDataHolder")]
public class UpgradeDataHolder : ScriptableObject
{
    public List<UpgradeObject> potentialUpgrades = new List<UpgradeObject>();
    public int Count => potentialUpgrades.Count;
}