using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverrideFloatWrapperValue : MonoBehaviour
{
    [SerializeField] private FloatVariable OverrideVariable;

    [SerializeField] private FloatValueWrapper _wrapper;

    private void OnEnable()
    {
        _wrapper.CurrentValue.value = OverrideVariable.value;
    }
}
