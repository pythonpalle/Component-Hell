using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [Header("Variable Objects")]
    [SerializeField] private IntVariable currentLevel;
    [SerializeField] private XpDataHolder _xpData;

    [Header("Events")]
    public UnityEvent<int> OnLevelUp;

    private void Awake()
    {
        currentLevel.value = 0;
    }

    public void OnAddXP(float xp)
    {
        if (_xpData.totalXP >= _xpData.xpNeededForNextLevel)
        {
            currentLevel.value++;
            OnLevelUp?.Invoke(currentLevel.value);
        }
    }
}
