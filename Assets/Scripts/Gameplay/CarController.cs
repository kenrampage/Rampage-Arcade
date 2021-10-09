using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private SOFMODParameterData fmodDataEngineRPM;
    private float engineRPM;

    [SerializeField] private SOFMODParameterData fmodDataSkid;
    private float skidValue;

    [SerializeField] private WheelCollider wheelColFL, wheelColFR, wheelColRL, wheelColRR;
    [SerializeField] private Transform wheelTransFL, wheelTransFR, wheelTransRL, wheelTransRR;
    [SerializeField] private Rigidbody carRb;
    [SerializeField] private Transform centerOfMassTarget;

    [SerializeField] private float baseMaxSteerAngle = 30;
    [SerializeField] private float motorForce = 5000;
    [SerializeField] private float brakeForce = 10000;
    [SerializeField] private float brakeSidewaysStiffnessModifier = .3f;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float skidThreshhold;

    private float currentMaxSteerAngle;
    private float currentSpeed;
    private float speedPercentage;
    private bool brakeOn = false;

    private WheelFrictionCurve sidewaysFrictionBaseRL, sidewaysFrictionBaseRR;
    private WheelFrictionCurve sidewaysFrictionBrakeRL, sidewaysFrictionBrakeRR;

    private void Start()
    {
        SetWheelFrictionBaseValues();
        SetCenterOfMass();
    }

    private void Update()
    {
        CalculateSpeedPercentage();
        CalculateSteerAngle();
        GetCurrentSpeed();
        CalculateEngineRPM();
        CalculateSkidAmount();
    }

    private void FixedUpdate()
    {
        UpdateWheelPoses();
    }


    public void Steer(Vector2 horizontalInput)
    {
        var steerAngle = currentMaxSteerAngle * horizontalInput.x;
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

    public void BrakeOn()
    {
        wheelColFL.brakeTorque = brakeForce;
        wheelColFR.brakeTorque = brakeForce;
        wheelColRL.brakeTorque = brakeForce;
        wheelColRR.brakeTorque = brakeForce;

        wheelColRL.sidewaysFriction = sidewaysFrictionBrakeRL;
        wheelColRR.sidewaysFriction = sidewaysFrictionBrakeRR;

        brakeOn = true;

    }

    public void BrakeOff()
    {
        wheelColFL.brakeTorque = 0;
        wheelColFR.brakeTorque = 0;
        wheelColRL.brakeTorque = 0;
        wheelColRR.brakeTorque = 0;

        wheelColRL.sidewaysFriction = sidewaysFrictionBaseRL;
        wheelColRR.sidewaysFriction = sidewaysFrictionBaseRR;

        brakeOn = false;
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

    private void CalculateSteerAngle()
    {
        if (currentSpeed <= 10)
        {
            currentMaxSteerAngle = baseMaxSteerAngle;
        }
        else if (currentSpeed > 10 && currentSpeed <= 16)
        {
            currentMaxSteerAngle = baseMaxSteerAngle * .6f;
        }
        else if (currentSpeed > 16 && currentSpeed <= 22)
        {
            currentMaxSteerAngle = baseMaxSteerAngle * .4f;
        }
        else if (currentSpeed > 22)
        {
            currentMaxSteerAngle = baseMaxSteerAngle * .3f;
        }
        else
        {
            currentMaxSteerAngle = baseMaxSteerAngle;
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

    private void GetCurrentSpeed()
    {
        currentSpeed = carRb.velocity.magnitude;
    }

    private void SetCenterOfMass()
    {
        carRb.centerOfMass = new Vector3(centerOfMassTarget.localPosition.x, centerOfMassTarget.localPosition.y, centerOfMassTarget.localPosition.z);
    }

    private void CalculateSpeedPercentage()
    {
        speedPercentage = currentSpeed / maxSpeed;
    }

    private void CalculateEngineRPM()
    {

        engineRPM = Mathf.Lerp(.2f, 1f, speedPercentage);
        fmodDataEngineRPM.FloatValue = engineRPM;
    }

    private void CalculateSkidAmount()
    {
        wheelColRL.GetGroundHit(out WheelHit hitRL);
        wheelColRR.GetGroundHit(out WheelHit hitRR);

        if (hitRL.sidewaysSlip > skidThreshhold || hitRL.sidewaysSlip < -skidThreshhold
        || hitRR.sidewaysSlip > skidThreshhold || hitRR.sidewaysSlip < -skidThreshhold
        || brakeOn)
        {
            fmodDataSkid.FloatValue = speedPercentage;
        }
        else
        {
            fmodDataSkid.FloatValue = 0;
        }
    }

}
