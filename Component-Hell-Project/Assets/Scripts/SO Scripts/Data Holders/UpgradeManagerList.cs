using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/UpgradeManagerList")]
public class UpgradeManagerList : ScriptableObject
{
    [SerializeField] private List<UpgradeManager> upgradeDataHolders = new List<UpgradeManager>();
    public List<UpgradeManager> UpgradeDataHolders => upgradeDataHolders;
}