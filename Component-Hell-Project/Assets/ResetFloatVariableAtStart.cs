using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFloatVariableAtStart : MonoBehaviour
{
    [SerializeField] private FloatVariable _floatVariable;
    
    void Start()
    {
        _floatVariable.value = 0;
    }
}
