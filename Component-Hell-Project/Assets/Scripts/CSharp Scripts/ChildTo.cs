using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTo : MonoBehaviour
{
    [SerializeField] private string tagName;
    
    void Start()
    {
        var toChildObject = GameObject.FindWithTag(tagName);
    }
} 
