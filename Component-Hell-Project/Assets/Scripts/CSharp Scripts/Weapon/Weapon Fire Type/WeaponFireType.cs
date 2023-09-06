using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponFireType : MonoBehaviour
{
    public abstract void Fire(Projectile projectile);
}
