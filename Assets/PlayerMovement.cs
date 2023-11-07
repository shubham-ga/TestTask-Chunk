using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rigidbody;
    public Vector3 moveInput;
    public float movespeed;
    float r;
    float targetRoationx;

    public float dis;
    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rigidbody.velocity = moveInput * movespeed;
    }


}
