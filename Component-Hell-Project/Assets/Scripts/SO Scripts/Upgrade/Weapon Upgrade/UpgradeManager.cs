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

    public void AddNextUpgrade()
    {
        var nextUpgrade = upgradePath.potentialUpgrades[counter];
        nextUpgrade.Apply(transform);
        counter++;

        if (counter >= upgradePath.Count)
        {
            upgradePathComplete = true;
        }
    }
}