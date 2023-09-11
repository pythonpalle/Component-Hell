using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [Header("Variable Objects")]
    [SerializeField] private IntVariable currentLevel;
    [SerializeField] private FloatVariable currentXP;
    [SerializeField] private FloatVariable neededXpForNextLevel;
    
    [Header("Settings")]
    [SerializeField] private float startValue = 10f;
    [SerializeField] private float baseValue = 1.5f;

    [Header("Events")]
    public UnityEvent<int> OnLevelUp;

    private void OnEnable()
    {
        UpdateNeededXPForNextLevel();
    }

    public void OnAddXP(float xp)
    {
        if (currentXP.value >= neededXpForNextLevel.value)
        {
            currentLevel.value++;
            UpdateNeededXPForNextLevel();
            OnLevelUp?.Invoke(currentLevel.value);
        }
    }

    private void UpdateNeededXPForNextLevel()
    {
        neededXpForNextLevel.value = 
            startValue * (currentLevel.value + 1) 
            + Mathf.Pow(baseValue, currentLevel.value); 
    }
}
