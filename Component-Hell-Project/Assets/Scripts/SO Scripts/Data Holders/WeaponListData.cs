using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/WeaponList")]
public class WeaponListData : ScriptableObject
{
    [SerializeField] private List<Weapon> _weapons;
    public List<Weapon> Weapons => _weapons;
}
