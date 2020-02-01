using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	[SerializeField] private Text _text;
	[SerializeField] private SpriteRenderer _image;
	[SerializeField] private Canvas _canvas;
	// Use this for initialization

	public void showMessage(Tutorial tutorial)
	{
		_text.text = tutorial.text[0];
		_image.sprite = tutorial.image;
		_canvas.enabled = true;
	}

	public void hideCanvas()
	{
		_canvas.enabled = false;
	}
}
