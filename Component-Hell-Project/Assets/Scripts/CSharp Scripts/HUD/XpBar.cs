using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    
    [SerializeField] private Slider _slider;

    [SerializeField] private XpDataHolder xpData;

    private float prevLevelNeeded = 0;
    private float nextLevelNeeded = 0;

    private void Start()
    {
        UpdateNeededValues();
        UpdateSliderValue();
    }

    public void UpdateNeededValues()
    {
        prevLevelNeeded = nextLevelNeeded;
        nextLevelNeeded = xpData.xpNeededForNextLevel;
    }

    public void UpdateSliderValue()
    {
        float current = xpData.totalXP - prevLevelNeeded;
        float max = nextLevelNeeded - prevLevelNeeded;
        
        _slider.value = current/max;
    }
}
