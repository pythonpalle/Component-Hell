using UnityEngine;

public class EffectTimeTransfer : MonoBehaviour, WeaponDataUpdateListener
{
    private EffectManager _effectManager;

    private void Awake()
    {
        _effectManager = GetComponent<EffectManager>();
    }

    public void OnWeaponDataUpdate(WeaponDataHolder data)
    {
        _effectManager.AddMultiplier(data.name, data.effectDuration.Value);
    } 
}