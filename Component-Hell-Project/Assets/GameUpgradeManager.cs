using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;


public class GameUpgradeManager : MonoBehaviour
{
    private static int MAX_UPGRADE_OPTIONS = 3;

    public UnityEvent<List<IUpgradable>> OnChosenOptions;

    public static GameUpgradeManager Instance;
    private GamePlayerWeaponManager _playerWeaponManager; 

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
        _playerWeaponManager = GamePlayerWeaponManager.Instance;
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
        List<IUpgradable> availableUpgrades = new List<IUpgradable>();

        // finds upgrades for used weapons
        foreach (var weapon in _playerWeaponManager.OwnedWeapons)
        {
            if (weapon.GetUpgradeManager().CanUpgrade())
            {
                availableUpgrades.Add(weapon);
            }
        }

        // TODO: Limit to a set amount
        // finds potential weapons
        foreach (var poolWeapon in _playerWeaponManager.PotentialWeaponPrefabs)
        {
            availableUpgrades.Add(poolWeapon);
        }

        // might not work
        Shuffle(availableUpgrades);

        List<IUpgradable> chosenOptions = ChooseOptionsFrom(availableUpgrades);
        OnChosenOptions?.Invoke(chosenOptions);
    }

    private static Random rng = new Random();  

    static void Shuffle<T>(IList<T> list)  
    {  
       // Fisher–Yates shuffle, from https://stackoverflow.com/questions/273313/randomize-a-listt
        
        int count = list.Count;  
        while (count > 1) {  
            count--;  
            int k = rng.Next(count + 1);  
            (list[k], list[count]) = (list[count], list[k]);
        }  
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

        int max = (availiableUpgrades.Count < MAX_UPGRADE_OPTIONS) ? availiableUpgrades.Count : MAX_UPGRADE_OPTIONS;

        for (int i = 0; i < max; i++)
        {
            chosenOptions.Add(availiableUpgrades[i]);
            Debug.Log($"Chosen option: {availiableUpgrades[i]}");
        }

        return chosenOptions;
    }
}