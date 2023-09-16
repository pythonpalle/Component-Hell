using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeObject : ScriptableObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class ComponentAddUpgrade : UpgradeObject
{
    [SerializeField] private ComponentAdder _componentAdder;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class UpgradeDataHolder : ScriptableObject
{
    [SerializeField] private List<UpgradeObject> potentialUpgrades;
    
    // serilized temporarily for test purposes
    [SerializeField] private List<UpgradeObject> appliedUpgrades;
    
    
}
