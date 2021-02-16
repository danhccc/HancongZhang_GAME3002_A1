/*
 * GAME 3002 Assignment 1
 * Made by Hancong Zhang
 * GBC ID: 101234068
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviourScript : MonoBehaviour
{
    // Reference of the ball rigid body
    Rigidbody ball;

    // The initial velocity of the ball
    [SerializeField]
    private float kickForce = 2;

    // Gravity
    private float gravity = -9.8f;

    // Ball's vector
    private float ballX, ballY, ballZ;

    //private float pi = 3.1415926f;

    // Verticle angle X
    private float theta = 0;

    // Horizontal angle Y
    private float direction = 0;

    // Starting position of the ball
    Vector3 StartingPosition = new Vector3(0.0f, 0.5f, -3.0f);

    // Boolean checkers
    private bool ballActivated, timer;

    // Timer
    private float startTime, deltaTime;

    // Start is called before the first frame update
    void Start()
    {
        // Setting the starting position and ball status
        transform.position = StartingPosition;
        timer = false;
        ballActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If ball not activated
        if (!ballActivated)
        {
            // Activate ball
            if (Input.GetKeyDown("4"))
            {
                Launch();
            }

            // Configure ball direction and theta angle
            if (Input.GetKeyDown("w"))
            { 
                if (theta <= 45)
                { theta += 5; }
            }
            if (Input.GetKeyDown("s"))
            { 
                if (theta > 0)
                { theta -= 5; }
            }
            if (Input.GetKeyDown("a"))
            {
                direction -= 5;
            }
            if (Input.GetKeyDown("d"))
            {
                direction += 5;
            }
        }
        else // If ball activated
        {
            if (Input.GetKeyDown("r"))
            {
                BallReset();
            }
            if (ballX > 5 || ballX < -5) BallReset();
            if (ballZ > 5 || ballZ < -5) BallReset();
            //if (ballX > 5 || ballX < -5) BallReset();

            // Getting delta time
            if (timer)
            {
                deltaTime = Time.time - startTime;
            }
            else
            {
                startTime = Time.time;
                deltaTime = startTime;
                timer = true;
            }
            
        }

    }

    void Launch()
    {
        ballActivated = true;

        ballZ = kickForce * Mathf.Cos(theta) * Mathf.Sin(theta) * deltaTime;
        ballX = kickForce * Mathf.Cos(theta) * Mathf.Cos(theta) * deltaTime;
        ballY = kickForce * Mathf.Sin(direction) * Mathf.Sin(direction) / 2 * gravity * deltaTime;

        if (ballY < 0) ballY = 0;
        transform.position = new Vector3(ballX, ballY, ballZ);
    }

    void BallReset()
    {
        transform.position = StartingPosition;
        ballX = ballY = ballZ = theta = direction = 0;
        ballActivated = false;
        timer = false;
    }
}
