using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameUpgradeManager : MonoBehaviour
{
    [SerializeField] int maxUpgradeOptions = 3;

    [SerializeField] private List<UpgradeManager> _upgradeManagers;

    public UnityEvent<List<UpgradeObject>> OnChosenOptions;

    // Start is called before the first frame update
    private void Start()
    {
        LevelManager.Instance.OnLevelUp.AddListener(OnLevelUp);
    }

    private void OnDestroy()
    {
        LevelManager.Instance.OnLevelUp.RemoveListener(OnLevelUp);
    }

    private void OnLevelUp(int levelNumber)
    {
        GetUpgradeOptions();
    }

    private void GetUpgradeOptions()
    {
        List<UpgradeObject> availiableUpgrades = new List<UpgradeObject>();

        foreach (var upgradeManager in _upgradeManagers)
        {
            if (upgradeManager.CanUpgrade())
            {
                availiableUpgrades.Add(upgradeManager.NextUpgrade());
            }
        }

        // might not work
        availiableUpgrades.Sort();

        List<UpgradeObject> chosenOptions = ChooseOptionsFrom(availiableUpgrades);
        OnChosenOptions?.Invoke(chosenOptions);
    }

    private List<UpgradeObject> ChooseOptionsFrom(List<UpgradeObject> availiableUpgrades)
    {
        var chosenOptions = new List<UpgradeObject>();

        int max = (availiableUpgrades.Count < maxUpgradeOptions) ? availiableUpgrades.Count : maxUpgradeOptions;
        Debug.Log("Max: " + max);

        for (int i = 0; i < max; i++)
        {
            chosenOptions.Add(availiableUpgrades[i]);
            Debug.Log($"Chosen option: {availiableUpgrades[i].name}");
        }

        return chosenOptions;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}