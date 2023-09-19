﻿using System.Reflection;
using UnityEngine;

public enum ModifyType
{
    Multiply,
    Add
}


public abstract class DataUpgradeObject : UpgradeObject
{
    [SerializeField] private ModifyType modifyType;
    [SerializeField] private float amount;

    protected void UpdateVariable(ScriptableObject holder, string name)
    {
        // Use reflection to get the field by name.
        FieldInfo field = holder.GetType().GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        
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