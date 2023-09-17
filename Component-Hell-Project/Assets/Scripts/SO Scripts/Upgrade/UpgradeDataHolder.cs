using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/DataHolder/UpgradeDataHolder")]
public class UpgradeDataHolder : ScriptableObject
{
    [Header("Upgrade Path")]
    [SerializeField] private UpgradePath upgradePath;
    public UpgradePath UpgradePath => upgradePath;

    [Header("Description")]
    [SerializeField] private string managerName;
    public string ManagerName => managerName;
    [SerializeField] private string managerDescription;
    public string ManagerDescription => managerDescription;
    [SerializeField] private Sprite image;
    public Sprite Image => image;
}