using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    public float angle = 0f;
    
    private void FixedUpdate()
    {
        //var x = Vector3.right * _speed * Time.deltaTime;
        
        transform.position += transform.right * _speed * Time.deltaTime * transform.localScale.normalized.x;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Background"))
        {
            Destroy(this.gameObject);
        }
    }
}
