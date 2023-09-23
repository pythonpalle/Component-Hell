using UnityEngine;

public class WeaponHandlerVector2Listener : Vector2Listener
{
    private WeaponHandler _weaponHandler;
    
    private void Awake()
    {
        _weaponHandler = GetComponent<WeaponHandler>();
    }

    public override void OnVector2Change(Vector2 direction)
    {
        _weaponHandler.OnVector2Change(direction);
    }
}