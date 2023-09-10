using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatValueComponent : MonoBehaviour
{
    public float baseValue = 1;
    public float currentValue = 1;
    
    void OnValidate()
    {
        currentValue = baseValue; 
    }
}
