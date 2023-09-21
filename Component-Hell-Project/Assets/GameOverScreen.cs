using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private RectTransform gameOverPopup;
    [SerializeField] private float timeTilPopUp;

    public void OnGameOver()
    {
        Invoke("PopupScreen", timeTilPopUp);
    }

    private void PopupScreen()
    {
        gameOverPopup.gameObject.SetActive(true);
        TimeManager.Instance.PauseTime();
    }
}
