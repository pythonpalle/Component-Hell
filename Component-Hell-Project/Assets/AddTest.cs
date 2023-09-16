using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTest : MonoBehaviour
{
    [SerializeField] private UpgradeManager upgradeManager;
    
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
