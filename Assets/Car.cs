using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    //public variables
    [Header("Physics")]
    public float acceleration = 0.05f;
    public float turnSpeed = 1f;
    public AudioSource engineSound;
    public AudioSource driftSound;
    public AudioSource reverseSound;

    //private variables
    float rotationAngle = 0;
    Rigidbody2D carRigidBody;
    float gasInput;
    float steerInput;

    void Start()
    {
        carRigidBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        gasInput = Convert.ToInt32(Input.GetKey(KeyCode.W)) - (Convert.ToInt32(Input.GetKey(KeyCode.Space))/2f);
        steerInput = Convert.ToInt32(Input.GetKey(KeyCode.D)) - Convert.ToInt32(Input.GetKey(KeyCode.A));

        //Audio logic
        if (Input.GetKey(KeyCode.W))
        {
            if(!engineSound.isPlaying)
                engineSound.Play();

            if(Input.GetKey(KeyCode.Space) && !driftSound.isPlaying)
                driftSound.Play();
            if(!Input.GetKey(KeyCode.Space))
                driftSound.Stop();
        }
        else
        {
            engineSound.Stop();
            if (Input.GetKey(KeyCode.Space) && !reverseSound.isPlaying)
            {
                reverseSound.Play();
            }
            if (!Input.GetKey(KeyCode.Space)) { reverseSound.Stop(); }
        }

    }
    private void FixedUpdate()
    {
        Vector2 gasForce = transform.right * gasInput * acceleration;
        carRigidBody.AddForce(-gasForce, ForceMode2D.Force);

        rotationAngle -= steerInput * turnSpeed;
        carRigidBody.MoveRotation(rotationAngle);
    }
}
