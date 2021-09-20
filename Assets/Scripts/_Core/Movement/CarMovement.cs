using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private WheelCollider wheelColFL, wheelColFR, wheelColRL, wheelColRR;
    [SerializeField] private Transform wheelTransFL, wheelTransFR, wheelTransRL, wheelTransRR;
    [SerializeField] private Rigidbody carRb;
    [SerializeField] private Transform centerOfMassTarget;

    [SerializeField] private float maxSteerAngle = 30;
    [SerializeField] private float currentSteerAngle;
    [SerializeField] private float motorForce = 50;
    [SerializeField] private float brakeForce = 500;
    [SerializeField] private float brakeSidewaysStiffnessModifier = .3f;
    [SerializeField] private float maxSpeed;
    [SerializeField] private bool reverseOn = false;

    private WheelFrictionCurve sidewaysFrictionBaseRL, sidewaysFrictionBaseRR;
    private WheelFrictionCurve sidewaysFrictionBrakeRL, sidewaysFrictionBrakeRR;
    [SerializeField] private float currentSpeed;

    private void Start()
    {
        SetWheelFrictionBaseValues();
        carRb.centerOfMass = new Vector3(centerOfMassTarget.localPosition.x, centerOfMassTarget.localPosition.y, centerOfMassTarget.localPosition.z);
    }

    private void Update()
    {
        currentSteerAngle = CalculateSteerAngle();
        currentSpeed = carRb.velocity.magnitude;
    }

    private void FixedUpdate()
    {
        UpdateWheelPoses();
    }


    public void Steer(Vector2 horizontalInput)
    {
        print("Horizontal Input: " + horizontalInput);
        var steerAngle = currentSteerAngle * horizontalInput.x;
        wheelColFL.steerAngle = steerAngle;
        wheelColFR.steerAngle = steerAngle;
    }

    public void Accelerate(float verticalInput)
    {
        if (currentSpeed < maxSpeed * .85f)
        {

            wheelColFL.motorTorque = motorForce * verticalInput;
            wheelColFR.motorTorque = motorForce * verticalInput;

        }
        else if (currentSpeed >= maxSpeed * .85f)
        {

            wheelColFL.motorTorque = (motorForce * .3f) * verticalInput;
            wheelColFR.motorTorque = (motorForce * .3f) * verticalInput;

        }
        else if (currentSpeed >= maxSpeed * .95f && currentSpeed < maxSpeed)
        {

            wheelColFL.motorTorque = (motorForce * .1f) * verticalInput;
            wheelColFR.motorTorque = (motorForce * .1f) * verticalInput;

        }
        else if (currentSpeed >= maxSpeed)
        {
            wheelColFL.motorTorque = 0;
            wheelColFR.motorTorque = 0;
        }
    }

    // public void AccelerateOff()
    // {
    //     wheelColFL.motorTorque = 0;
    //     wheelColFR.motorTorque = 0;
    // }

    // public void ReverseOn()
    // {
    //     if (currentSpeed < maxSpeed * .85f)
    //     {
    //         wheelColFL.motorTorque = -motorForce;
    //         wheelColFR.motorTorque = -motorForce;
    //     }
    //     else if (currentSpeed >= maxSpeed * .85f)
    //     {
    //         wheelColFL.motorTorque = -motorForce * .3f;
    //         wheelColFR.motorTorque = -motorForce * .3f;
    //     }
    //     else if (currentSpeed >= maxSpeed * .95f && currentSpeed < maxSpeed)
    //     {
    //         wheelColFL.motorTorque = -motorForce * .1f;
    //         wheelColFR.motorTorque = -motorForce * .1f;
    //     }
    //     else if (currentSpeed >= maxSpeed)
    //     {
    //         wheelColFL.motorTorque = 0;
    //         wheelColFR.motorTorque = 0;
    //     }
    // }

    // public void ReverseOff()
    // {
    //     wheelColFL.motorTorque = 0;
    //     wheelColFR.motorTorque = 0;
    // }

    public void ToggleReverse()
    {
        reverseOn = !reverseOn;
    }

    public void BrakeOn()
    {
        wheelColFL.brakeTorque = brakeForce;
        wheelColFR.brakeTorque = brakeForce;
        wheelColRL.brakeTorque = brakeForce;
        wheelColRR.brakeTorque = brakeForce;

        wheelColRL.sidewaysFriction = sidewaysFrictionBrakeRL;
        wheelColRR.sidewaysFriction = sidewaysFrictionBrakeRR;

    }

    public void BrakeOff()
    {
        wheelColFL.brakeTorque = 0;
        wheelColFR.brakeTorque = 0;
        wheelColRL.brakeTorque = 0;
        wheelColRR.brakeTorque = 0;

        wheelColRL.sidewaysFriction = sidewaysFrictionBaseRL;
        wheelColRR.sidewaysFriction = sidewaysFrictionBaseRR;
    }

    private void SetWheelFrictionBaseValues()
    {

        sidewaysFrictionBaseRL = wheelColRL.sidewaysFriction;
        sidewaysFrictionBaseRR = wheelColRR.sidewaysFriction;

        sidewaysFrictionBrakeRL = sidewaysFrictionBaseRL;
        sidewaysFrictionBrakeRR = sidewaysFrictionBaseRR;

        sidewaysFrictionBrakeRL.stiffness *= brakeSidewaysStiffnessModifier;
        sidewaysFrictionBrakeRR.stiffness *= brakeSidewaysStiffnessModifier;

    }

    private float CalculateSteerAngle()
    {
        if (currentSpeed <= 10)
        {
            return maxSteerAngle;
        }
        else if (currentSpeed > 10 && currentSpeed <= 16)
        {
            return maxSteerAngle * .6f;
        }
        else if (currentSpeed > 16 && currentSpeed <= 22)
        {
            return maxSteerAngle * .4f;
        }
        else if (currentSpeed > 22)
        {
            return maxSteerAngle * .3f;
        }
        else
        {
            return maxSteerAngle;
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

}
