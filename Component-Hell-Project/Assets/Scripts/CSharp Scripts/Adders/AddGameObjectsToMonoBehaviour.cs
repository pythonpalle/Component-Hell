using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGameObjectsToMonoBehaviour : MonoBehaviour
{
    public List<MonoBehaviour> prefabsToAdd;

    public void AddGameObjects(MonoBehaviour toBehaviour)
    {
        AddGameObjects(toBehaviour.gameObject);
    }
    
    public void AddGameObjects(GameObject monoBehaviour)
    {
        foreach (var prefab in prefabsToAdd)
        {
            var instance = Instantiate(prefab, monoBehaviour.transform);
        }
    }

    public void AddPrefab(MonoBehaviour prefab)
    {
        prefabsToAdd.Add(prefab);
    }
}
