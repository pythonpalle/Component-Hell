using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverManager : MonoBehaviour
{
    public UnityEvent OnGameOver;

    public void OnPlayerDeath()
    {
        OnGameOver?.Invoke();
    }
}
