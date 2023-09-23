using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Types/SetMovementController")]
public class SetMovementControllerUpgrade : UpgradeObject
{
    [SerializeField] private MovementControllerBase movementController;

    public override void Apply(Transform owner)
    {
        var weaponDataContainer = owner.GetComponent<WeaponDataContainer>();
        weaponDataContainer.WeaponData.moveController = movementController; 
    }
}