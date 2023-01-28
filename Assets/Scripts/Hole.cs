using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    // variables 
    public GameObject EndScreen;

    public GameObject PlayingScreen;

    public GameObject GolfBall;

    public Rigidbody GolfBallRigidBody;

    public GameObject GameManager;


    // when the ball hits the hole 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GolfBall)
        {
            // turn on end of level screen
            EndScreen.SetActive(true);
            // turn off instructions
            PlayingScreen.SetActive(false);
            ResetGolfBallVelocity();

            //GameManager.SetActive(false);
        }
    }

    void ResetGolfBallVelocity()
    {
        // set velocity to 0
        GolfBallRigidBody.velocity = Vector3.zero;

        // set angular velocity to 0
        GolfBallRigidBody.angularVelocity = Vector3.zero;

    }

}
