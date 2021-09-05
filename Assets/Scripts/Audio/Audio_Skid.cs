using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Audio_Skid : MonoBehaviour
{
    public CarControllerC car;
    public StudioEventEmitter emitter;
    public float speedPerc;

    private GameManager gameManager;

    public float skidThreshhold;

    public bool isSkidding;

    // public float skidRRForward;
    public float skidRRSide;

    // public float skidRLForward;
    public float skidRLSide;

    public float skidPerc;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if(gameManager.CurrentGameState == GameManager.GameState.GAMEACTIVE)
        {
            speedPerc = car.currentSpeed / car.maxSpeed;
        } else
        {
            speedPerc = 0;
        }

        if (car.wheelColFL.GetGroundHit(out WheelHit hitRR))
        {
            skidRRSide = hitRR.sidewaysSlip;
            // skidRRForward = hitRR.forwardSlip;

        }

        if (car.wheelColFL.GetGroundHit(out WheelHit hitRL))
        {
            skidRLSide = hitRL.sidewaysSlip;
            // skidRLForward = hitRL.forwardSlip;

        }

        if (skidRRSide > skidThreshhold || skidRRSide < -skidThreshhold 
        || skidRLSide > skidThreshhold || skidRLSide < -skidThreshhold
        || car.brakeOn)
        {
            skidPerc = speedPerc;
        }
        else
        {
            skidPerc = 0;
        } 

        emitter.SetParameter("SkidPerc", skidPerc);


    }
}
