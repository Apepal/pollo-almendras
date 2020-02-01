using System;

using UnityEngine;

public abstract class EventAbstract : MonoBehaviour
{
    private TextManager manager;

    private void Start()
    {
        manager = GameObject.Find("TextManager").GetComponent<TextManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onPlayerCallback();
        }
    }

    public abstract void onPlayerCallback();

    protected void showDialog(Dialog dialog)
    {
        manager.showDialog(dialog);
    }
}
