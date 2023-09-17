using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/UpgradePath")]
public class UpgradePath : ScriptableObject
{
    public List<UpgradeObject> potentialUpgrades = new List<UpgradeObject>();
    public int Count => potentialUpgrades.Count;
}