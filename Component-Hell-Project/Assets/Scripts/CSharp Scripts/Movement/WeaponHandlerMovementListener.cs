using UnityEngine;

public class WeaponHandlerMovementListener : MovementListener
{
    private WeaponHandler _weaponHandler;
    
    private void Awake()
    {
        _weaponHandler = GetComponent<WeaponHandler>();
    }

    public override void OnMovementChange(Vector2 direction)
    {
        _weaponHandler.OnMovementChange(direction);
    }
}