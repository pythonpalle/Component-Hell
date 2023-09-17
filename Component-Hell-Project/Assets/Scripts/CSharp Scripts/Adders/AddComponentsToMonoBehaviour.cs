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
    public MonoScript script;
    public ChildTarget childTarget;
}

public enum ChildTarget
{
    Movement,
    Health,
    Effect,
    Damage,
    Misc,
    Size,
    Root
}

public class AddComponentsToMonoBehaviour : MonoBehaviour
{
    [SerializeField] private List<ComponentAdder> componentsToAdd = new List<ComponentAdder>();

    public void AddComponents(MonoBehaviour behaviour)
    {
        AddComponents(behaviour.gameObject);
    }
    
    public void AddComponents(GameObject toAddObject)
    {
        foreach (var adder in componentsToAdd)
        {
            Transform childObject;

            if (adder.childTarget == ChildTarget.Root)
                childObject = toAddObject.transform;
            else
                childObject = toAddObject.transform.GetChild((int)adder.childTarget);
            
            childObject.gameObject.AddComponent(adder.script.GetClass());
        }
    }

    public void AddNewComponent(ComponentAdder adder)
    {
        componentsToAdd.Add(adder);
    }
}
