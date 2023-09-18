using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private bool destroyRoot;
    
    public void SelfDestroy(float timeTilDestruct = 0)
    {
        Invoke("DestroyMe", timeTilDestruct);
        
        // var objectToDestroy = destroyRoot ? transform.root.gameObject : gameObject;
        // Destroy(objectToDestroy, timeTilDestruct);
    }

    public void CancelDestroy()
    {
        CancelInvoke("DestroyMe");
    }

    void DestroyMe()
    {
        var objectToDestroy = destroyRoot ? transform.root.gameObject : gameObject;
        Destroy(objectToDestroy);
    }
}
