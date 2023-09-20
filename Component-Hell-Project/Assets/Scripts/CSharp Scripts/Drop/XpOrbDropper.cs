using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpOrbDropper : MonoBehaviour
{
    public void Drop()
    {
        XpPoolManager.Instance.SpawnOrb(transform.position);
    }
}
