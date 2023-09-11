using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGameObjectsToMonoBehaviour : MonoBehaviour
{
    public List<GameComponent> prefabsToAdd;

    public void Add(GameComponent monoBehaviour)
    {
        foreach (var prefab in prefabsToAdd)
        {
            var comp = Instantiate(prefab, monoBehaviour.transform);
            comp.Setup(monoBehaviour.MetaContainer);
        }
    }
}
