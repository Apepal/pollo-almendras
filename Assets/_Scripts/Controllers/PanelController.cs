using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    private GameController _gameController;
    private Canvas _canvas;

    private const string BACK_BUTTON = "BackButton";
    
    void Start()
    {
        _canvas = GetComponentInParent<Canvas>();
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        Button[] buttons = this.GetComponentsInChildren<Button>(true);
        foreach (var button in buttons)
        {
            button.onClick.AddListener(delegate
            {
                switch (button.name)
                {
                    case BACK_BUTTON:
                        this.hide();
                        _gameController.changeStatus(GameStatus.RESUME);
                        break;
                }
            });
        }
    }

    public void show()
    {
        _canvas.enabled = (true);
    }

    public void show(string message)
    {
        show();
    }

    public void hide()
    {
        _canvas.enabled = (false);
    }
}
