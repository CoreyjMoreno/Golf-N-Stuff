using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{

    public TMP_Text ScoreDisplay;

    public TMP_Text EndScoreDisplay;

    public TMP_Text TermScoreDisplay;

    public TMP_Text ParDisplay;

    public GameStateMachine StateMachine;

    Dictionary<int, string>? strokeText = new Dictionary<int, string>()
    {
        {-4 , "Condor!" },
        {-3 , "Albatross!" },
        {-2 , "Eagle!" },
        {-1 , "Birdie!" },
        {0  , "Par" },
        {1  , "Bogey" },
        {2  , "Double-Bogey" },
        {3  , "Triple-Bogey"},
        {4  , "Quadruple-Bogey"}
    };

    private void Start()
    {
        // update the Par Display
        ParDisplay.text = "Par: " + StateMachine.Par;
    }

    public void SetText()
    {

        // Display the golf term using a ternairy operator
        // If its a hole in one display such a thing, else display the proper term
        TermScoreDisplay.text = StateMachine.PuttCount == 1 ? "Hole in one!" : strokeText[ StateMachine.PuttCount - StateMachine.Par ];
    }

    public void UpdatePuttCount()
    {
        // update Score counter display
        ScoreDisplay.text = "Putt Count: " + StateMachine.PuttCount;
    }

    public void DisplayEndStats()
    {
        // set end display
        EndScoreDisplay.text = "Hole in: " + StateMachine.PuttCount;
    }

}
