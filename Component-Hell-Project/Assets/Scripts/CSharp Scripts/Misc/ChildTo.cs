using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTo : MonoBehaviour
{
    [SerializeField] private string tagName = "Player";
    
    void OnEnable()
    {
        var toChildObject = GameObject.FindWithTag(tagName);
        transform.parent = toChildObject.transform;
    }
}