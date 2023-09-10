using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class InstantiateGameObject : MonoBehaviour
{
    [SerializeField] GameObject prefabToInstantiate;
    
    public void InstantiateObject()
    {
        Instantiate(prefabToInstantiate, transform.position, quaternion.identity); 
    }
}
