using UnityEngine;
using UnityEngine.Events;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private UpgradeDataHolder upgradePath;

    private int counter = 0;
    private bool upgradePathComplete;
    
    public bool CanUpgrade()
    {
        return !upgradePathComplete;
    }

    public UpgradeObject NextUpgrade()
    {
        return upgradePath.potentialUpgrades[counter];
    }

    public void AddNextUpgrade()
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