using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    
    [SerializeField] private Slider _slider;

    [Header("Scriptable Variables")]
    [SerializeField] private FloatVariable playerXP;
    [SerializeField] private FloatVariable neededXpForNextLevel;

    private float prevLevelNeeded = 0;
    private float nextLevelNeeded = 0;

    private void OnEnable()
    {
        UpdateNeededValues();
        UpdateSliderValue();
    }

    public void UpdateNeededValues()
    {
        prevLevelNeeded = nextLevelNeeded;
        nextLevelNeeded = neededXpForNextLevel.value;
    }

    public void UpdateSliderValue()
    {
        float current = playerXP.value - prevLevelNeeded;
        float max = nextLevelNeeded - prevLevelNeeded;

        _slider.value = current/max;
    }
}
