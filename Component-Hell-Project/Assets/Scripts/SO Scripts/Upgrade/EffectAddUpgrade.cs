using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Types/EffectAdd")]
public class EffectAddUpgrade : UpgradeObject
{
    [SerializeField] private EffectType effectType;
    public override void Apply(Transform owner)
    {
        WeaponDataContainer weaponDataContainer = owner.GetComponent<WeaponDataContainer>();
        var weaponData = weaponDataContainer.WeaponData;
        
        weaponData.EffectAppliers.Add(new EffectTypeWrapper(effectType));
    } 
}