using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnTransformChildrenChangedMessanger : MonoBehaviour
{
    [SerializeField] private string methodToInvoke = "TransformChildrenChanged";
    
    private void OnTransformChildrenChanged()
    {
        gameObject.SendMessage(methodToInvoke, SendMessageOptions.DontRequireReceiver);
    
        foreach (Transform child in transform)
        {
            child.gameObject.SendMessage("TransformChildrenChanged", SendMessageOptions.DontRequireReceiver); 
        }
    }
}
