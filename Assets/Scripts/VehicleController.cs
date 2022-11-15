using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    private Vector3 _movement;

    [SerializeField] private float _speed;  // 10
    
    // Update is called once per frame
    private void Update()
    {
        ListenInput();
        HandleMovement();
    }

    private void ListenInput()
    {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.z = Input.GetAxis("Vertical");

    }

    private void HandleMovement()
    {
        transform.Translate(Time.deltaTime * _speed * _movement);
    }
}
