using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPhys : MonoBehaviour
{

    private Rigidbody RB;
    public float WhenToStartSlowing;

    public float GrassMultiplier;

    public GameStateMachine StateMachine;

    // awake is called before start
    void Awake()
    {
        RB = this.gameObject.GetComponent<Rigidbody>();
    }

    public void slowDownGrass()
    {
        RB.AddForce(-RB.velocity.normalized * GrassMultiplier);

    }
}

    