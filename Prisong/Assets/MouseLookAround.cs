using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouseLookAround : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = 200f;
    public Vector3 deltaMove;
    //public float speed = 200;
    public GameObject mover;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
       turn.y = Math.Max(-100f, turn.y);
       turn.y = Math.Min(90f, turn.y);
       mover.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
       transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);   
    }
}

