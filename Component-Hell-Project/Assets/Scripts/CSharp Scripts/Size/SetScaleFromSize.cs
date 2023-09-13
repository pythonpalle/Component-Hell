using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScaleFromSize : GameComponent
{
    [SerializeField] private Transform toSizeTransform;

    private void OnEnable()
    {
        SetScaleFromSizeComponent();
    }

    private void SetScaleFromSizeComponent()
    {
        toSizeTransform.localScale = Vector3.one * _metaContainer.SizeContainer.ValueWrapper.CurrentValue.value;
    }
}
