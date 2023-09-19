using System;
using System.Reflection;
using UnityEngine;


[CreateAssetMenu(menuName = "Upgrade/Types/WeaponData")]
public class WeaponDataUpgrade : DataUpgradeObject
{
    [SerializeField] private WeaponDataType weaponDataType;

    public override void Apply(Transform owner) 
    {
        WeaponDataContainer weaponDataContainer = owner.GetComponent<WeaponDataContainer>();
        var weaponData = weaponDataContainer.WeaponData;

        UpdateVariable(weaponData, weaponDataType.ToString());
    }
}