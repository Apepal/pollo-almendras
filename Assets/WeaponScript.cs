using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float minYRotation = -45f;
    public float maxYRotation = 45f; // For proof of concept, basically
    [SerializeField]
    private GameObject _bala;

    private ShotScript _shot;
    float currentRotation = 0.0f;
    Quaternion yRotation;
    [SerializeField] private float speed = 40f;

    private void Start()
    {

    }

    public void change(float axis)
    {
        currentRotation += axis * speed * Time.deltaTime;
        currentRotation = Mathf.Clamp(currentRotation, minYRotation, maxYRotation);
        transform.localEulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, currentRotation);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            var quaternion = transform.localScale.x < 0
                ? Quaternion.Inverse(transform.localRotation)
                : transform.localRotation;
            var clone = Instantiate(_bala, transform.position, quaternion);
            clone.transform.localScale = transform.parent.localScale;
        }
    }
}
