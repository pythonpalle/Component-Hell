using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XpManager : MonoBehaviour
{
    public static XpManager Instance { get; private set; }
    
    [SerializeField] private FloatVariable playerXP;
    [SerializeField] private FloatVariable neededXpForNextLevel;

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
    }

    public void AddXP(float xp)
    {
        playerXP.value += xp;
        OnAddXP?.Invoke(xp);
    }
}
