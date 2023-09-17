using System;
using UnityEngine;
using UnityEngine.Events;


public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private UpgradeDataHolder _upgradeDataHolder;
    public UpgradeDataHolder DataHolder => _upgradeDataHolder;
    
    private bool upgradePathComplete;
    private int counter = 0;
    public int Counter => counter;
    
    public bool IsInstantiated { get; private set; }

    private void Awake()
    {
        IsInstantiated = true;
    }

    public bool CanUpgrade()
    {
        return !upgradePathComplete;
    }

    public UpgradeObject NextUpgrade()
    {
        if (CanUpgrade())
            return _upgradeDataHolder.UpgradePath.potentialUpgrades[counter];

        return null;
    }

    public void ApplyNextUpgrade()
    {
        var nextUpgrade = NextUpgrade();
        nextUpgrade.Apply(transform);
        counter++;

        if (counter >= _upgradeDataHolder.UpgradePath.Count)
        {
            upgradePathComplete = true;
        }
    }
}