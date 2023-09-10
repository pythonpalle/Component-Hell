using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelfDestruct))]
public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] private float timeTilDespawn = 5f;
    
    private void OnEnable()
    {
        GetComponent<SelfDestruct>().SelfDestroy(timeTilDespawn);
    }
}
