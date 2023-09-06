using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputWeaponController : WeaponController
{
    public override bool WantsToShoot()
    {
        return Input.GetButton("Fire1");
    }
}
