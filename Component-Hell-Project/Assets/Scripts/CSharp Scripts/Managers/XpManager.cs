using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XpManager : MonoBehaviour
{
    public static XpManager Instance { get; private set; }

    [SerializeField] private XpDataHolder xpData;
    
    [Header("Settings")]
    [SerializeField] private float startValue = 10f;
    [SerializeField] private float baseValue = 1.5f;

    public UnityEvent<float> OnAddXP;

    private void OnEnable()
    {
        if (!Instance || Instance == this)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

        ResetXp();
        UpdateNeededXPForNextLevel(0);
    }

    private void ResetXp()
    {
        xpData.totalXP = 0;
        xpData.xpNeededForNextLevel = 0;
    }

    public void AddXP(float xp)
    {
        xpData.totalXP += xp;
        OnAddXP?.Invoke(xp);
    }

    public void OnLevelUp(int level)
    {
        UpdateNeededXPForNextLevel(level);
        
    }
    
    private void UpdateNeededXPForNextLevel(int level)
    {
        xpData.xpNeededForNextLevel = 
            startValue * (level + 1) 
            + Mathf.Pow(baseValue, level); 
    }
}
