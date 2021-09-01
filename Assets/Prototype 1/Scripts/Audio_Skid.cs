using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Audio_Skid : MonoBehaviour
{
    public CarControllerC car;
    public StudioEventEmitter emitter;
    public float speedPerc;

    private GameManager1 gameManager1;

    public float skidThreshhold;

    public bool isSkidding;

    // public float skidRRForward;
    public float skidRRSide;

    // public float skidRLForward;
    public float skidRLSide;

    public float skidPerc;


    private void Start()
    {
        gameManager1 = GameManager1.Instance;
    }

    // Update is called once per frame
    void Update()
    {

        if(gameManager1.gameIsActive)
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
