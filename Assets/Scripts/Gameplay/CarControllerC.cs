using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarControllerC : MonoBehaviour
{
    
    public float horizontalInput;
    public float verticalInput;
    private float steerAngle;

    public Rigidbody carRb;
    public Transform centerOfMass;

    public WheelCollider wheelColFL, wheelColFR;
    public WheelCollider wheelColRL, wheelColRR;
    public Transform wheelTransFL, wheelTransFR;
    public Transform wheelTransRL, wheelTransRR;


    public float maxSteerAngle = 30;
    public float currentSteerAngle;
    public float motorForce = 50;
    public float brakeForce = 500;
    public float toppleAngle = 90;

    public float currentSpeed;
    public float maxSpeed;

    public bool brakeOn;

    public WheelFrictionCurve rearWheelFCBase;
    // public WheelFrictionCurve rearWheelFC;
    public WheelFrictionCurve rearWheelFCBrake;

    private GameManager gameManager;
    private ScoreKeeper scoreKeeper;

    public float engineRPM;

    // public ParticleSystem particlePickup;

    // public static event Action onPickup;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        // scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        rearWheelFCBase = wheelColRL.sidewaysFriction;
        rearWheelFCBrake = rearWheelFCBase;
        rearWheelFCBrake.stiffness = rearWheelFCBrake.stiffness * .3f;


        
        carRb.centerOfMass = new Vector3(centerOfMass.localPosition.x, centerOfMass.localPosition.y, centerOfMass.localPosition.z);

    }

    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        brakeOn = Input.GetKey(KeyCode.Space);
    }

    private void Steer()
    {
        steerAngle = currentSteerAngle * horizontalInput;
        wheelColFL.steerAngle = steerAngle;
        wheelColFR.steerAngle = steerAngle;

    }

    private void Accelerate()
    {


        if (currentSpeed < maxSpeed * .85f)
        {
            wheelColFL.motorTorque = verticalInput * motorForce;
            wheelColFR.motorTorque = verticalInput * motorForce;
        }
        else if (currentSpeed >= maxSpeed * .85f)
        {
            wheelColFL.motorTorque = (verticalInput * motorForce) * .3f;
            wheelColFR.motorTorque = (verticalInput * motorForce) * .3f;
        }
        else if (currentSpeed >= maxSpeed * .95f && currentSpeed < maxSpeed)
        {
            wheelColFL.motorTorque = (verticalInput * motorForce) * .1f;
            wheelColFR.motorTorque = (verticalInput * motorForce) * .1f;
        }
        else if (currentSpeed >= maxSpeed)
        {
            wheelColFL.motorTorque = 0;
            wheelColFR.motorTorque = 0;
        }


    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(wheelColFL, wheelTransFL);
        UpdateWheelPose(wheelColFR, wheelTransFR);
        UpdateWheelPose(wheelColRL, wheelTransRL);
        UpdateWheelPose(wheelColRR, wheelTransRR);

    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void Update()
    {

        engineRPM = (wheelColFL.rpm + wheelColFR.rpm) / 2;

        if (transform.up.y < toppleAngle)
        {
            if (brakeOn)
            {
                this.transform.rotation = Quaternion.Euler(0, this.transform.eulerAngles.y, 0);
            }
        }

        GetInput();
        currentSpeed = carRb.velocity.magnitude;

        if (currentSpeed <= 10)
        {
            currentSteerAngle = maxSteerAngle;
        }
        else if (currentSpeed > 10 && currentSpeed <= 16)
        {
            currentSteerAngle = maxSteerAngle * .6f;
        }
        else if (currentSpeed > 16 && currentSpeed <= 22)
        {
            currentSteerAngle = maxSteerAngle * .4f;
        }
        else if (currentSpeed > 22)
        {
            currentSteerAngle = maxSteerAngle * .3f;
        }

    }

    private void FixedUpdate()
    {

        Steer();
        UpdateWheelPoses();

        if (gameManager.CurrentGameState == GameState.GAMEACTIVE)
        {
            Accelerate();

            if (brakeOn)
            {


                BrakeOn();
            }
            else
            {

                BrakeOff();

            }
        }
        else
        {
            wheelColFL.brakeTorque = 1000000;
            wheelColFR.brakeTorque = 1000000;
            wheelColRL.brakeTorque = 1000000;
            wheelColRR.brakeTorque = 1000000;

        }

    }

    private void BrakeOn()
    {
        wheelColFL.brakeTorque = brakeForce;
        wheelColFR.brakeTorque = brakeForce;
        wheelColRL.brakeTorque = brakeForce;
        wheelColRR.brakeTorque = brakeForce;

        wheelColRL.sidewaysFriction = rearWheelFCBrake;
        wheelColRR.sidewaysFriction = rearWheelFCBrake;


    }

    private void BrakeOff()
    {
        wheelColFL.brakeTorque = 0;
        wheelColFR.brakeTorque = 0;
        wheelColRL.brakeTorque = 0;
        wheelColRR.brakeTorque = 0;
        wheelColRL.sidewaysFriction = rearWheelFCBase;
        wheelColRR.sidewaysFriction = rearWheelFCBase;

    }

    // private void OnTriggerEnter(Collider other)
    // {

    //     if (other.CompareTag("Pickup"))
    //     {
    //         if (gameManager.CurrentGameState == GameState.GAMEACTIVE)
    //         {
    //             // particlePickup.Play();
    //             onPickup?.Invoke();              
    //         }
    //     }

    // }

}
