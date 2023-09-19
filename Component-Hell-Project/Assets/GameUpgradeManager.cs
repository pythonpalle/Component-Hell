using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;


public class GameUpgradeManager : MonoBehaviour
{
    private static int MAX_UPGRADE_OPTIONS = 3;

    public UnityEvent<List<UpgradeManager>> OnChosenOptions;

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
        List<UpgradeManager> availableUpgrades = new List<UpgradeManager>();

        AddOwnedWeapons(availableUpgrades);
        AddPotentialWeapons(availableUpgrades);
        AddOwnedAbilities(availableUpgrades);
        AddPotentialAbilities(availableUpgrades);

        // might not work
        Shuffle(availableUpgrades);

        List<UpgradeManager> chosenOptions = ChooseOptionsFrom(availableUpgrades);
        OnChosenOptions?.Invoke(chosenOptions);
    }

    private void AddPotentialAbilities(List<UpgradeManager> availableUpgrades)
    {
        foreach (var upgradeManager in GamePlayerAbilityManager.Instance.PotentialUpgradeAbilities)
        {
            availableUpgrades.Add(upgradeManager);
        }
    }

    private void AddOwnedAbilities(List<UpgradeManager> availableUpgrades)
    {
        foreach (var upgrade  in GamePlayerAbilityManager.Instance.OwnedUpgradeManagers)
        {
            if (upgrade.CanUpgrade())
                availableUpgrades.Add(upgrade);
        }
    }

    private void AddPotentialWeapons(List<UpgradeManager> availableUpgrades)
    {
        // TODO: Limit to a set amount
        // finds potential weapons
        foreach (var poolWeapon in _playerWeaponManager.PotentialWeaponPrefabs)
        {
            availableUpgrades.Add(poolWeapon.GetComponent<UpgradeManager>());
        }
    }

    private void AddOwnedWeapons(List<UpgradeManager> availableUpgrades)
    {
        // finds upgrades for used weapons
        foreach (var weapon  in _playerWeaponManager.OwnedWeapons)
        {
            var weaponUpgradeManger = weapon.GetComponent<UpgradeManager>();
            
            if (weaponUpgradeManger.CanUpgrade())
            {
                availableUpgrades.Add(weaponUpgradeManger);
            }
        }
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
    public void ApplyUpgrade(UpgradeManager upgrade)
    {
        if (!upgrade.IsInstantiated)
        {
            switch (upgrade.ManagerType)
            {
                case UpgradeMangerType.Weapon:
                    var weapon = GamePlayerWeaponManager.Instance.AddWeapon(upgrade.GetComponent<Weapon>());
                    upgrade = weapon.GetComponent<UpgradeManager>();
                    break;
                
                case UpgradeMangerType.Health:
                    upgrade = GamePlayerAbilityManager.Instance.AddHealth(upgrade);
                    break;
                
                case UpgradeMangerType.Movement:
                    upgrade = GamePlayerAbilityManager.Instance.AddMovement(upgrade);
                    break;
                
            }
            
        }
        
        upgrade.ApplyNextUpgrade(); 
        
    }

    private List<UpgradeManager> ChooseOptionsFrom(List<UpgradeManager> availiableUpgrades)
    {
        var chosenOptions = new List<UpgradeManager>();

        int max = (availiableUpgrades.Count < MAX_UPGRADE_OPTIONS) ? availiableUpgrades.Count : MAX_UPGRADE_OPTIONS;

        for (int i = 0; i < max; i++)
        {
            chosenOptions.Add(availiableUpgrades[i]);
            Debug.Log($"Chosen option: {availiableUpgrades[i]}");
        }

        return chosenOptions;
    }
}