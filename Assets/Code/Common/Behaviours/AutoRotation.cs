using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour
{
    void Update()
    {
        transform.RotateAround(Vector3.up,  Time.deltaTime);
    }
}
