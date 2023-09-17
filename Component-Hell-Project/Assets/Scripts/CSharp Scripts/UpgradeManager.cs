using UnityEngine;
using UnityEngine.Events;

public class UpgradeManager : MonoBehaviour
{
    [Header("Upgrade Path")]
    [SerializeField] private UpgradeDataHolder upgradePath;
    private bool upgradePathComplete;
    private int counter = 0;
    public int Counter => counter;

    [Header("Description")]
    [SerializeField] private string managerName;
    public string ManagerName => managerName;
    [SerializeField] private Sprite sprite;
    public Sprite Sprite => sprite;

    
    
    
    public bool CanUpgrade()
    {
        return !upgradePathComplete;
    }

    public UpgradeObject NextUpgrade()
    {
        return upgradePath.potentialUpgrades[counter];
    }

    public void ApplyNextUpgrade()
    {
        var nextUpgrade = NextUpgrade();
        nextUpgrade.Apply(transform);
        counter++;

        if (counter >= upgradePath.Count)
        {
            upgradePathComplete = true;
        }
    }
}