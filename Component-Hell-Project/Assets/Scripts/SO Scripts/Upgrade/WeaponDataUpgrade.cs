using System;
using System.Reflection;
using UnityEngine;



public enum ModifyType
{
    Multiply,
    Add
}


[CreateAssetMenu(menuName = "Upgrade/Types/WeaponData")]
public class WeaponDataUpgrade : UpgradeObject
{
    [SerializeField] private WeaponDataType weaponDataType;
    [SerializeField] private ModifyType modifyType;
    [SerializeField] private float amount;

    public override void Apply(Transform owner)
    {
        WeaponDataContainer weapon = owner.GetComponent<WeaponDataContainer>();
        var weaponData = weapon.WeaponData;

        UpdateVariable(weaponData);
    }
    
    void UpdateVariable(WeaponDataHolder holder)
    {
        // Use reflection to get the field by name.
        FieldInfo field = holder.GetType().GetField(weaponDataType.ToString(), BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        
        if (field != null)
        {
            // Make sure the field is of type DynamicFloat.
            if (field.FieldType == typeof(DynamicFloat))
            {
                DynamicFloat dynamicFloat = (DynamicFloat)field.GetValue(holder);

                switch (modifyType)
                {
                    case ModifyType.Add:
                        dynamicFloat.AddAdder(this.name, amount, true);
                        break;
                    
                    case ModifyType.Multiply:
                        dynamicFloat.AddMultiplier(this.name, amount, true);
                        break;
                }
                
            }
            else
            {
                Debug.LogError("Field " + name + " is not of type DynamicFloat.");
            }
        }
        else
        {
            Debug.LogError("Field " + name + " not found in WeaponDataHolder.");
        }
    }
}