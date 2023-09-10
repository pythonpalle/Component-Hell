using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    private float max = 10;

    [SerializeField] private FloatVariable playerXP;
    [SerializeField] private Slider _slider;

    private void Update()
    {
        _slider.value = playerXP.value / max;
    }
}
