using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectApplyHandler : MonoBehaviour, IWeaponDataUpdateListener
{
    [SerializeField] private List<EffectType> EffectAppliers;
    [SerializeField] private float effectDuration = 1;

    public void OnWeaponDataUpdate(WeaponDataHolder data)
    {
        EffectAppliers = data.EffectAppliers;
        effectDuration = data.effectDuration.Value;
    }

    public void TryApplyEffects(Collider2D other)
    {
        var effectListenerManager = other.GetComponentInChildren<EffectListenerManager>();
        if (!effectListenerManager)
        {
            return;
        }
        
        effectListenerManager.ApplyEffects(this, EffectAppliers, effectDuration);
    }
}
