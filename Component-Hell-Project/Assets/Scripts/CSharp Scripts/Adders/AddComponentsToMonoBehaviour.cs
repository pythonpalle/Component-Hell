using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.Serialization;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using Object = UnityEngine.Object;


[Serializable]
public struct ComponentAdder
{
    public MonoScript Script;
    public int childIndex;
}

public class AddComponentsToMonoBehaviour : MonoBehaviour
{
    [SerializeField] private List<ComponentAdder> componentsToAdd = new List<ComponentAdder>();

    public void AddComponents(GameObject toAddObject)
    {
        foreach (var adder in componentsToAdd)
        {
            var childObject = toAddObject.transform.GetChild(adder.childIndex);
            childObject.gameObject.AddComponent(adder.Script.GetClass());
        }
    }
}
