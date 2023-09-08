using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGameObjectsToMonoBehaviour : MonoBehaviour
{
    public List<GameObject> prefabsToAdd;

    public void Add(MonoBehaviour monoBehaviour)
    {
        foreach (var prefab in prefabsToAdd)
        {
            Instantiate(prefab, monoBehaviour.transform);
        }
    }
}
