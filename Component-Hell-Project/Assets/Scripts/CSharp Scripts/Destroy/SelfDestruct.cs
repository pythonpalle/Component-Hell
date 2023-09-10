using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private bool destroyRoot;
    
    public void SelfDestroy(float timeTilDestruct = 0)
    {
        var objectToDestroy = destroyRoot ? transform.root.gameObject : gameObject;
        Destroy(objectToDestroy, timeTilDestruct);
    }
}
