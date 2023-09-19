using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GamePlayerAbilityManager : MonoBehaviour
{
    public static GamePlayerAbilityManager Instance;
    
    [SerializeField] private UpgradeManagerList playerWeaponUpgradeManagers;
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
        foreach (var upgradeManager in playerWeaponUpgradeManagers.UpgradeDataHolders)
        {
            PotentialUpgradeAbilities.Add(upgradeManager);
        }
    }

    public UpgradeManager AddHealth(UpgradeManager upgradePrefab)
    {
        HealthManager playerHealth = playerTransform.GetComponentInChildren<HealthManager>();
        
        var upgradeInstance = playerHealth.AddComponent<UpgradeManager>();
        upgradeInstance.SetData(upgradePrefab.DataHolder);
        upgradeInstance.ManagerType = upgradePrefab.ManagerType;
        
        PotentialUpgradeAbilities.Remove(upgradePrefab);
        OwnedUpgradeManagers.Add(upgradeInstance);
        OnAddedManager?.Invoke(upgradeInstance);

        return upgradeInstance;
    }
}
