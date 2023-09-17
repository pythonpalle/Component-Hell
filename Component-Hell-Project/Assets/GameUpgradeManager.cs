using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameUpgradeManager : MonoBehaviour
{
    [SerializeField] int maxUpgradeOptions = 3;

    [SerializeField] private List<UpgradeManager> weaponUpgradeManagers = new List<UpgradeManager>();
    

    public UnityEvent<List<UpgradeManager>> OnChosenOptions;

    public static GameUpgradeManager Instance;

    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

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

    public void OnAddedWeapon(Weapon weapon)
    {
        weaponUpgradeManagers.Add(weapon.GetComponent<UpgradeManager>());
    }

    private void GetUpgradeOptions()
    {
        List<UpgradeManager> availiableUpgrades = new List<UpgradeManager>();

        foreach (var upgradeManager in weaponUpgradeManagers)
        {
            if (upgradeManager.CanUpgrade())
            {
                availiableUpgrades.Add(upgradeManager);
            }
        }

        // might not work
        availiableUpgrades.Sort();

        List<UpgradeManager> chosenOptions = ChooseOptionsFrom(availiableUpgrades);
        OnChosenOptions?.Invoke(chosenOptions);
    }

    public void ApplyUpgrade(UpgradeManager manager)
    {
        manager.ApplyNextUpgrade();
    }

    private List<UpgradeManager> ChooseOptionsFrom(List<UpgradeManager> availiableUpgrades)
    {
        var chosenOptions = new List<UpgradeManager>();

        int max = (availiableUpgrades.Count < maxUpgradeOptions) ? availiableUpgrades.Count : maxUpgradeOptions;

        for (int i = 0; i < max; i++)
        {
            chosenOptions.Add(availiableUpgrades[i]);
            Debug.Log($"Chosen option: {availiableUpgrades[i].name}");
        }

        return chosenOptions;
    }
}