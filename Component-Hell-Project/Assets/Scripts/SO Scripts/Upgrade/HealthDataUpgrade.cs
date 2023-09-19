using System.Reflection;
using UnityEngine;

public enum HealthDataType
{
    maxHealth,
    armour,
    regeneration
}

[CreateAssetMenu(menuName = "Upgrade/Types/HealthData")]
public class HealthDataUpgrade : DataUpgradeObject
{
    [SerializeField] private HealthDataType healthDataType;

    public override void Apply(Transform owner)
    {
        HealthManager healthManager = owner.GetComponent<HealthManager>();
        var weaponData = healthManager.DataHolder;

        UpdateVariable(weaponData, healthDataType.ToString());
    }
}