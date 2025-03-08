using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text playerLifeText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text timeSurvivedText;

    public void SetPlayerLife(float life)
        => playerLifeText.text = $"Player Life: {life}";

    public void SetTimerText(int time)
        => timerText.text = $"{time}";

    public void SetGameOver(int secondsSurvived)
    {
        timeSurvivedText.text = $"Has sobrevivido {secondsSurvived} segundos";
        gameOverPanel.SetActive(true);
    }

}
