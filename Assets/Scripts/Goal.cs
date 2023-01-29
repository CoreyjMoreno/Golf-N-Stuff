using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public GameStateMachine StateMachine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StateMachine.ChangeState(GameStateMachine.GameState.END);
        }
    }
}
