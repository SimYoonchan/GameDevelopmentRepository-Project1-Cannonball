using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
        //We must now drag the paddle GameObject to the [SerializeField] box to connect the ball and paddle.
        // I think the "paddle1" variable is now storing all of the info from the class "Paddle.cs" file.
        //And since this is [SerializeField], whatever GameObject we drop in, this object is now representing "paddle1"

    Vector2 paddleToBallVector;
        //We stated the variable "paddleToBallVector" to be the struct "Vector2"

    bool hasStarted = false;
        //Note: Just writing "bool hasStarted;" works as well.

    [SerializeField] float launchX = 1f;
    [SerializeField] float launchY = 18f;

    [SerializeField] AudioClip[] cannonballSoundEffects;

    [SerializeField] float highestRandomVelocity = 0.25f;


    //Cache reference:
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;


    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
            //Writing this here just identifies this once rather than writing it multiple times.
        myRigidBody2D = GetComponent<Rigidbody2D>();
        //Writing this here just identifies this once rather than writing it multiple times.
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted == false)
        {
            LockBallToPaddle();
            LaunchBallFromPaddle();
            //We need to include the LaunchBallFromPaddle() because we have to go through
            //this if false statement as the "hasStarted = true" occurs in the
            //LaunchBallFromPaddle()
        }

        //if (hasStarted == true)
        //{
        //    LaunchBallFromPaddle();
        //}
            //Get rid of this above code so that launch doesn't happen more than once.
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePositionWithBall = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePositionWithBall + paddleToBallVector;
    }

    private void LaunchBallFromPaddle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(launchX, launchY);

            hasStarted = true;
            
            //this comes after we need launch to happen first and then hasStarted changes to true.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 vectorTweakForRandomness = new Vector2(UnityEngine.Random.Range(0f, highestRandomVelocity), UnityEngine.Random.Range(0f, highestRandomVelocity));

        if (hasStarted == true)
        {
            AudioClip soundEffects = cannonballSoundEffects[UnityEngine.Random.Range(0, cannonballSoundEffects.Length)];
            GetComponent<AudioSource>().PlayOneShot(soundEffects);

            myRigidBody2D.velocity += vectorTweakForRandomness;
        }
    }
}
