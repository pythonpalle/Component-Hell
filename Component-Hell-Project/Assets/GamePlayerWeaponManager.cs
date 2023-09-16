using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerWeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponHandler playerWeaponHandler;
    
    [SerializeField] private List<Weapon> startingWeaponPrefabs;
    [SerializeField] private List<Weapon> startingWeaponInstances = new List<Weapon>();
    
    // Start is called before the first frame update
    void Start()
    {
        playerWeaponHandler.OnWeaponAdded.AddListener(OnWeaponAdded);
        
        foreach (var startingWeapon in startingWeaponPrefabs)
        {
            playerWeaponHandler.AddWeapon(startingWeapon);
        }
        
        
    }

    private void OnWeaponAdded(Weapon arg0)
    {
        startingWeaponInstances.Add(arg0);
        upgradeManager = arg0.GetComponent<UpgradeManager>();
    }

    private UpgradeManager upgradeManager;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddUpgrade(); 
        }
    }

    private void AddUpgrade()
    {
        if (upgradeManager.CanUpgrade())
        {
            upgradeManager.AddNextUpgrade();
        }
        else
        {
            Debug.Log("Out of upgrades!");
        }
    } 
}
