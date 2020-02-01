using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class TextManager : MonoBehaviour
{

    [SerializeField]
    private UIManager _manager;

    [SerializeField] private GameController _gameController;

    private Dialog _dialog;
    private int position = 0;

    private bool isEnabledTutorial = false;

    public void showDialog(Dialog dialog)
    {
        _gameController.changeStatus(GameStatus.PAUSED);
        this._dialog = dialog;
        this.isEnabledTutorial = true;
        this.position = 0;
    }
    
    private void FixedUpdate()
    {
        if (!isEnabledTutorial) return;
        _manager.showMessage(_dialog.tutorials[position]);
        if (!Input.anyKeyDown) return;
        position++;
        if (position == _dialog.tutorials.Length)
        {
            isEnabledTutorial = false;
            _gameController.changeStatus(GameStatus.RESUME);
        }
    }
}
