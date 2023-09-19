using UnityEngine;

public enum MovementDataType
{
    moveSpeed,
}

[CreateAssetMenu(menuName = "Upgrade/Types/MovementData")]
public class MovementDataUpgrade : DataUpgradeObject
{
    [SerializeField] private MovementDataType healthDataType;

    public override void Apply(Transform owner)
    {
        MovementManager movementManager = owner.GetComponent<MovementManager>();
        var moveData = movementManager.DataHolder;

        UpdateVariable(moveData, healthDataType.ToString());
    }
}