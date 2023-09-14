using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTo : GameComponent
{
    [SerializeField] private string tagName;
    
    void Start()
    {
        var toChildObject = GameObject.FindWithTag(tagName);
        _metaContainer.transform.parent = toChildObject.transform;
    }
}
