using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerBase playerBase;
    [SerializeField] private UIController uiController;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        playerBase.OnHit += PlayerHit;
        player.OnDie += GameOver;
        player.OnHit += UpdatePlayerLifes;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        uiController.SetTimerText(Convert.ToInt32(timer));
    }

    private void GameOver()
    {
        uiController.SetGameOver(Convert.ToInt32(timer));

        Time.timeScale = 0;
    }

    private void PlayerHit(float damage)
    {
        player.Hit(damage);
    }

    private void UpdatePlayerLifes(float lifes)
    {
        uiController.SetPlayerLife(lifes);
    }
}
