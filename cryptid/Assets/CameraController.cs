﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    bool lockXMovement;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;



    // Use this for initialization
    void Start () {
		
	}

    void Update()
    {
        if (lockXMovement)
        {
            yaw = transform.eulerAngles.y;
        }
        else
        {
            yaw += speedH * Input.GetAxis("Mouse X");
        }
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
