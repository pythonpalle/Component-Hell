using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/WeaponList")]
internal class WeaponListHolder : ScriptableObject
{
    public List<Weapon> Weapons;
}