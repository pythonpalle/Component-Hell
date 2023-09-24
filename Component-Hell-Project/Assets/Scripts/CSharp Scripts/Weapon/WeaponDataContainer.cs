using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDataContainer : MonoBehaviour
{
    [SerializeField] private WeaponDataHolder weaponData;
    public WeaponDataHolder WeaponData => weaponData;
    [SerializeField] private bool instantiate;

    private void Awake()
    {
        if (instantiate) weaponData = Instantiate(weaponData);
    }

    public static void TransferData(WeaponDataHolder @from, WeaponDataHolder to)
    {
        string owner = from.name;
        
        to.attackDamage.AddMultiplier(owner, from.attackDamage.Value);
        to.attackSize.AddMultiplier(owner, from.attackSize.Value);
        to.effectDuration.AddMultiplier(owner, from.effectDuration.Value);
        to.lifeTime.AddMultiplier(owner, from.lifeTime.Value);
        
        to.attackSpeed.AddMultiplier(owner, from.attackSpeed.Value);

        to.burstCooldown.AddMultiplier(owner, from.burstCooldown.Value);
        to.shotCooldown.AddMultiplier(owner, from.shotCooldown.Value);
        
        to.amount.AddAdder(owner, from.amount.Value);
        to.penetration.AddAdder(owner, from.penetration.Value);

        foreach (var effectType in from.EffectAppliers)
        {
            if (!to.EffectAppliers.Contains(effectType))
            {
                to.EffectAppliers.Add(effectType);
            }
        }

    }

    public void UpdateData(WeaponDataHolder fromData)
    {
        TransferData(fromData, weaponData);
    }
}
