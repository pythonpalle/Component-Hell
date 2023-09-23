using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    public void Create(WeaponDataHolder weaponData, Vector2 weaponDirection)
    {
        OnWeaponDataUpdate?.Invoke(weaponData);
        OnDirectionDataUpdate?.Invoke(weaponDirection);
    } 
    
    public UnityEvent<WeaponDataHolder> OnWeaponDataUpdate;
    public UnityEvent<Vector2> OnDirectionDataUpdate;
}
