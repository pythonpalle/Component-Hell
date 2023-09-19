using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamePlayerAbilityManager : MonoBehaviour
{
    public static GamePlayerAbilityManager Instance;
    
    [Header("Weapon")]
    [SerializeField] private WeaponHandler playerWeaponHandler;
    [SerializeField] private UpgradeDataList playerWeaponUpgradeDatas;
    
    [Header("Movement")]
    [SerializeField] private MovementManager playerMovementManager;
    [SerializeField] private UpgradeDataList playerMovementUpgradeDatas;

    [Header("Health")]
    [SerializeField] private HealthManager playerHealthManager;
    [SerializeField] private UpgradeDataList playerHealthUpgradeDatas;

    public List<UpgradeDataHolder> OwnedUpgradeAbilities { get; private set; } = new List<UpgradeDataHolder>();
    public List<UpgradeDataHolder> PotentialUpgradeAbilities { get; private set; } = new List<UpgradeDataHolder>();

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
        
    }
}
