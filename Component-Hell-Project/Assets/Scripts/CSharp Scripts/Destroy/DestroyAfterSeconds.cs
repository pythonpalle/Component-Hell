using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelfDestruct))]
public class DestroyAfterSeconds : MonoBehaviour
{
    private SelfDestruct _selfDestruct;
    
    [SerializeField] private float timeTilDespawn = 1f;

    private void Awake()
    {
        _selfDestruct = GetComponent<SelfDestruct>();
    }

    private void OnEnable()
    {
        _selfDestruct.SelfDestroy(timeTilDespawn);
    }

    public void SetLifeTime(float lifeTime)
    {
        _selfDestruct.CancelDestroy();
        timeTilDespawn *= lifeTime;
        _selfDestruct.SelfDestroy(timeTilDespawn);
    }
}
