using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFireWeaponController : WeaponController
{
    public override bool WantsToShoot()
    {
        return true;
    }
}
