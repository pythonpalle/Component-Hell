using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        UnPauseTime();
    }

    public void PauseTime()
    {
        Time.timeScale = 0;
    }
    
    public void UnPauseTime()
    {
        Time.timeScale = 1;
    }
}
