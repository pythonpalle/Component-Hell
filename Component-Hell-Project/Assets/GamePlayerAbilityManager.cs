using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GamePlayerAbilityManager : MonoBehaviour
{
    public static GamePlayerAbilityManager Instance;
    
    [SerializeField] private UpgradeManagerList playerUpgradePool;
    [SerializeField] private Transform playerTransform;

    public List<UpgradeManager> OwnedUpgradeManagers { get; private set; } = new List<UpgradeManager>();
    public List<UpgradeManager> PotentialUpgradeAbilities { get; private set; } = new List<UpgradeManager>();

    public UnityEvent<UpgradeManager> OnAddedManager;

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

    void Start()
    {
        InitialisePotentialUpgrades();
    }

    private void InitialisePotentialUpgrades()
    {
        foreach (var upgradeManager in playerUpgradePool.UpgradeDataHolders)
        {
            PotentialUpgradeAbilities.Add(upgradeManager);
        }
    }

    public UpgradeManager AddHealth(UpgradeManager upgradePrefab)
    {
        HealthManager playerHealth = playerTransform.GetComponentInChildren<HealthManager>();
        return AddUpgrade(upgradePrefab, playerHealth);

        // var upgradeInstance = playerHealth.AddComponent<UpgradeManager>();
        // upgradeInstance.SetData(upgradePrefab.DataHolder);
        // upgradeInstance.ManagerType = upgradePrefab.ManagerType;
        //
        // PotentialUpgradeAbilities.Remove(upgradePrefab);
        // OwnedUpgradeManagers.Add(upgradeInstance);
        // OnAddedManager?.Invoke(upgradeInstance);
        //
        // return upgradeInstance;
    }
    
    public UpgradeManager AddMovement(UpgradeManager upgradePrefab)
    {
        MovementManager playerMovement = playerTransform.GetComponentInChildren<MovementManager>();
        return AddUpgrade(upgradePrefab, playerMovement);

        
        // var upgradeInstance = playerMovement.AddComponent<UpgradeManager>();
        // upgradeInstance.SetData(upgradePrefab.DataHolder);
        // upgradeInstance.ManagerType = upgradePrefab.ManagerType;
        //
        // PotentialUpgradeAbilities.Remove(upgradePrefab);
        // OwnedUpgradeManagers.Add(upgradeInstance);
        // OnAddedManager?.Invoke(upgradeInstance);
        //
        // return upgradeInstance;
    }

    private UpgradeManager AddUpgrade(UpgradeManager upgradePrefab, MonoBehaviour toAddComponentBehaviour)
    {
        var upgradeInstance = toAddComponentBehaviour.AddComponent<UpgradeManager>();
        upgradeInstance.SetData(upgradePrefab.DataHolder);
        upgradeInstance.ManagerType = upgradePrefab.ManagerType;
        
        PotentialUpgradeAbilities.Remove(upgradePrefab);
        OwnedUpgradeManagers.Add(upgradeInstance);
        OnAddedManager?.Invoke(upgradeInstance);

        return upgradeInstance;
    }
}
