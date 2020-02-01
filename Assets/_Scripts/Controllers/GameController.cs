using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private PlayerScript _playerScript;
    
    private int lifes = 3;
    private int lot = 0;
    public GameStatus currentStatus = GameStatus.PAUSED;
    [SerializeField]
    private PanelController panelController;

    [SerializeField]
    private Vector2 lastPointTransform = Vector2.zero;
    

    public void changeStatus(GameStatus status)
    {
        switch (status)
        {
            case GameStatus.LOSE:
                endGame();
                break;
            case GameStatus.PAUSED:
                pauseGame(true);
                break;
            case GameStatus.RESUME:
                pauseGame(false);
                break;
            case GameStatus.START:
                resetGame();
                break;
            default:
                throw new ArgumentOutOfRangeException("status", status, null);
        }
    }

    private void pauseGame(bool pause)
    {
        _playerScript.setPaused(pause);
        currentStatus = GameStatus.RESUME;
    }

    private void endGame()
    {
        _playerScript.setPaused(true);
        _playerScript.die();
        currentStatus = GameStatus.PAUSED;
    }

    public void getDamage()
    {
        _playerScript.damage();
        lifes--;
        if (lifes == 0)
        {
            endGame();
        }
    }

    private void resetGame()
    {
        lifes = 3;
        _playerScript.setPaused(true);
        _playerScript.moveTo(lastPointTransform);
        currentStatus = GameStatus.RESUME;
    }

    private void showPanelMenu()
    {
        panelController.show();
    }

    void showPanelMenu(string message)
    {
        panelController.show(message);
    }

    void hidePanelMenu()
    {
        panelController.hide();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentStatus == GameStatus.PAUSED)
            {
                currentStatus = GameStatus.START;
                changeStatus(GameStatus.START);
                hidePanelMenu();
            }
            else
            {
                currentStatus = GameStatus.PAUSED;
                changeStatus(GameStatus.PAUSED);
                showPanelMenu();
            }
        }
    }

    public void addLot(int lot)
    {
        this.lot += lot;
    }
}

public enum GameStatus
{
    PAUSED, RESUME, START, LOSE
}
