using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private SpeedComponent speed;
    [SerializeField] private DamageComponent damage;
    [SerializeField] private DirectionComponent direction;
    
    public void SetUp(Weapon weapon)
    {
        speed.currentValue = speed.baseValue * weapon.SpeedComponent.currentValue;
        damage.currentValue = damage.baseValue * weapon.DamageComponent.currentValue;
        direction.Value = weapon.DirectionComponent.Value;
    }
}
