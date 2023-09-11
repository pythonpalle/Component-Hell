using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFloatVariablesAtAwake : MonoBehaviour
{
    [SerializeField] private List<FloatVariable> floatVariables;
    
    void Awake()
    {
        foreach (var floatVar in floatVariables)
        {
            floatVar.value = 0;
        }
    }
} 
