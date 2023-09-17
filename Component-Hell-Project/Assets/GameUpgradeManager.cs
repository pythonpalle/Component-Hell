using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameUpgradeManager : MonoBehaviour
{
    [SerializeField] int maxUpgradeOptions = 3;

    [SerializeField] private List<Weapon> weapons = new List<Weapon>();

    [SerializeField] private WeaponListData weaponPool;

    public UnityEvent<List<IUpgradable>> OnChosenOptions;

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
        weapons.Add(weapon);
    }

    private void GetUpgradeOptions()
    {
        List<IUpgradable> availableUpgrades = new List<IUpgradable>();

        // finds upgrades for used weapons
        foreach (var weapon in weapons)
        {
            if (weapon.GetUpgradeManager().CanUpgrade())
            {
                availableUpgrades.Add(weapon);
            }
        }

        // TODO: Limit to a set amount
        // finds potential weapons
        foreach (var poolWeapon in weaponPool.Weapons)
        {
            availableUpgrades.Add(poolWeapon);
        }

        // might not work
        availableUpgrades.Sort();

        List<IUpgradable> chosenOptions = ChooseOptionsFrom(availableUpgrades);
        OnChosenOptions?.Invoke(chosenOptions);
    }

    public void ApplyUpgrade(IUpgradable upgrade)
    {
        // if uninstantiated weapon
        if (upgrade is Weapon w && !upgrade.GetUpgradeManager().IsInstantiated)
        {
            GamePlayerWeaponManager.Instance.AddWeapon(w);
        }
        else
        {
            upgrade.GetUpgradeManager().ApplyNextUpgrade();
        }
    }

    private List<IUpgradable> ChooseOptionsFrom(List<IUpgradable> availiableUpgrades)
    {
        var chosenOptions = new List<IUpgradable>();

        int max = (availiableUpgrades.Count < maxUpgradeOptions) ? availiableUpgrades.Count : maxUpgradeOptions;

        for (int i = 0; i < max; i++)
        {
            chosenOptions.Add(availiableUpgrades[i]);
            Debug.Log($"Chosen option: {availiableUpgrades[i]}");
        }

        return chosenOptions;
    }
}