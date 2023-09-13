using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponPrefab;
    public UnityEvent<Weapon> OnPickUp;

    public void TryPickupWeapon(Collider2D other)
    {
        var weaponHandler = other.GetComponentInChildren<WeaponHandler>();
        if (!weaponHandler)
            return;

        weaponHandler.AddWeapon(weaponPrefab);
        OnPickUp?.Invoke(weaponPrefab);
    }
}
