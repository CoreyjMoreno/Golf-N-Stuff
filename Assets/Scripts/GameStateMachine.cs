using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStateMachine : MonoBehaviour
{
    public Putter PutterObject;

    public CameraOrbit CameraObject;

    public GameObject PlayingLevelScreen;

    public GameObject EndLevelScreen;

    public Rigidbody GolfBall;

    public float yPosition;

    public float WaitIdleTimeMax;
    float WaitIdleTime = 0;

    public float MinSpeed;

    public int MinYValue;

    public int PuttCount = 0;

    public TMP_Text ScoreDisplay;

    public TMP_Text EndScoreDisplay;

    public TMP_Text TermScoreDisplay;

    public int Par;

    public TMP_Text ParDisplay;

    private Vector3 lastPos;
    public enum GameState
    {
        AIMIMG,
        PUTTING,
        WAITING,
        END
    }
    public GameState currentState;

    // Start is called before the first frame update
    void Start()
    {
        // update the Par Display
        ParDisplay.text = "Par: " + Par;
        // set end level screen to off
        EndLevelScreen.SetActive(false);
        // set playing level screen to on
        PlayingLevelScreen.SetActive(true);
        // start the game in aiming
        ChangeState(GameState.AIMIMG);
    }

    // Update is called once per frame
    void Update()
    {
        // do things continuously depending on which state were in
        switch (currentState)
        {
            case (GameState.AIMIMG):
                break;

            case (GameState.PUTTING):
                break;

            case (GameState.WAITING):
                
                // if ball is in the hole
                if (EndLevelScreen.activeSelf)
                {
                    // End of Level reached
                    ChangeState(GameState.END);
                }

                // ball is below a certin vertical height aka out of bounds, reset to previous putt
                if (GolfBall.transform.position.y <  MinYValue)
                {
                    ResetGolfBallVelocity();
                    GolfBall.transform.position = lastPos;
                }
                // look to see if golfball velocity is below a certain threshhold
                if (GolfBall.velocity.magnitude < MinSpeed)
                {
                    // start counting
                    WaitIdleTime += Time.deltaTime;

                    // if we are not moving for x amount of time
                    if (WaitIdleTime > WaitIdleTimeMax)
                    {
                        // change to aiming
                        ChangeState(GameState.AIMIMG);
                        resetCounter();
                    }
                }
                else
                {
                    resetCounter();
                }
                break;
        }
    }


    // handler for changing state
    public void ChangeState(GameState newState)
    {
        // set the current state
        currentState = newState;

        // call state initialization
        switch (currentState)
        {
            case (GameState.AIMIMG):
                ToAiming();
                break;

            case (GameState.PUTTING):
                ToPutting();
                break;

            case (GameState.WAITING):
                ToWaiting();
                break;

            case (GameState.END):
                ToEnd();
                break;

        }

    }

    // set up aiming game state
    public void ToAiming()
    {   
        // record the last position of the golf ball 
        lastPos = GolfBall.transform.position;

        // Enable the aiming line renderer
        CameraObject.EnableAimLine();

        // Enable Camera Movement
        CameraObject.EnableCameraControlls();

        // Dsiable putter if not already
        PutterObject.DisablePutter();

        
        ResetGolfBallVelocity();

    }

    // set up putting game state
    public void ToPutting()
    {
        // disable the aim line renderer
        CameraObject.DisableAimLine();

        // disable camera controlls
        CameraObject.DisableCameraControlls();

        // enable the putter object
        PutterObject.EnablePutter();

    }

    // set up waiting game state
    public void ToWaiting()
    {
        // Dsiable putter
        PutterObject.DisablePutter();

        // Enable Camera controlls after a grace period from putting
        CameraObject.SleepThenEnable();

        // turn off indicator
        CameraObject.DisableAimLine();

        // Count A Put
        // add one count to the put counter
        PuttCount++;
        
        // update Score counter display
        ScoreDisplay.text = "Putt Count: " + PuttCount;
        
        

    }

    // end of level
    public void ToEnd()
    {
        // set end display
        EndScoreDisplay.text = "Hole in: " + PuttCount;

        // display the golf score term

            // hole in one
        if (PuttCount == 1)
        {
            TermScoreDisplay.text = "HOLE-N-ONE";
        }
        else
        {
            switch (PuttCount - Par)
            {
                case (-2):
                    TermScoreDisplay.text = "Eagle!";
                break;

                case (-1):
                    TermScoreDisplay.text = "Birdie";
                break;

                case (0):
                    TermScoreDisplay.text = "Par";
                break;

                case (1):
                    TermScoreDisplay.text = "Bogey";
                break;

                case (2):
                    TermScoreDisplay.text = "Double-Bogey";
                break;

                case (3):
                    TermScoreDisplay.text = "Triple-Bogey";
                break;
            }
        }
        
        // Enable Camera Movement
        CameraObject.EnableCameraControlls();

        // Dsiable putter if not already
        PutterObject.DisablePutter();

        ResetGolfBallVelocity();
        
        
    }

    void resetCounter()
    {
        WaitIdleTime = 0;
    }


    void ResetGolfBallVelocity()
    {
        // set velocity to 0
        GolfBall.velocity = Vector3.zero;

        // set angular velocity to 0
        GolfBall.angularVelocity = Vector3.zero;

    }

   
}
