using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScaleFromSize : MonoBehaviour
{
    private SizeComponent _sizeComponent;
    
    private void Awake()
    {
        _sizeComponent = GetComponent<SizeComponent>();
    }

    private void Update()
    {
        SetScaleFromSizeComponent();
    }

    public void SetScaleFromSizeComponent()
    {
        transform.localScale = Vector3.one * _sizeComponent.currentValue;
    }
}
