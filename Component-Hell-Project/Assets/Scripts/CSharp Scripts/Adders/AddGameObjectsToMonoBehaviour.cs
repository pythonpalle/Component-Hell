using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGameObjectsToMonoBehaviour : MonoBehaviour
{
    public List<MonoBehaviour> prefabsToAdd;

    public void Add(GameComponent monoBehaviour)
    {
        foreach (var prefab in prefabsToAdd)
        {
            var instance = Instantiate(prefab, monoBehaviour.transform);
        }
    }
}
