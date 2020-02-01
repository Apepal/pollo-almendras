using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected GameController _gameController;
    protected Animator _animator;
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int lot;
    [SerializeField] protected float pointA, pointB;
    private static readonly int Damage = Animator.StringToHash("Damage");
    private float movementType = 1f;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        OnStart();
    }

    private void FixedUpdate()
    {
        if (transform.position.x < pointA)
        {
            movementType = 1f;
        } else if (transform.position.x > pointB)
        {
            movementType = -1f;
        }

        transform.Translate(Vector3.right * movementType * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Player"))
        {
            _gameController.getDamage();
        }
        else if (other.CompareTag("Shot"))
        {
            health--;
            Destroy(other.gameObject);
            if (health == 0)
            {
                _gameController.addLot(lot);
                Destroy(this.gameObject);
            }
            else
            {
                _animator.SetTrigger(Damage);
            }

        }
    }

    public abstract void Attack();
    public abstract void OnStart();
    public abstract void OnFixedUpdate();
}
