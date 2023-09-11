using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetIntVariableAtAwake : MonoBehaviour
{
    [SerializeField] private List<IntVariable> _intVariable;
    
    void Awake() 
    {
        foreach (var intVar in _intVariable)
        {
            intVar.value = 0;
        }
    }
}
