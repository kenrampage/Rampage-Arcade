using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarController : MonoBehaviour
{

    //[SerializeField] float speed = 20f;
    [SerializeField] float horsePower = 20f;
    [SerializeField] float turnSpeed = 20f;
    [SerializeField] float horizontalInput;
    [SerializeField] float forwardInput;
    [SerializeField] float rpm;
    public float speed;
    [SerializeField] int wheelsOnGround;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    private Rigidbody playerRb;
    [SerializeField] List<WheelCollider> allWheels;



    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    void FixedUpdate()
    {

        if (IsOnGround())
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);

            speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
            speedometerText.SetText("Speed: " + speed + "mph");

            rpm = Mathf.Round(speed % 30);
            rpmText.SetText("RPM :" + rpm);
        }



    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;

        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
