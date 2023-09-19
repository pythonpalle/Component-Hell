using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/UpgradeDataList")]
public class UpgradeDataList : ScriptableObject
{
    [SerializeField] private List<UpgradeDataHolder> upgradeDataHolders = new List<UpgradeDataHolder>();
    public List<UpgradeDataHolder> UpgradeDataHolders => upgradeDataHolders;
}