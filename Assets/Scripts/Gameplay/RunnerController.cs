using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMODUnity;

public class RunnerController : MonoBehaviour
{

    [SerializeField] private SOGameStateKeeper gameStateKeeper;
    private Rigidbody playerRb;

    [SerializeField] private float jumpTimeCurrent;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpTimeMax;
    [SerializeField] private float jumpTimeThreshold;
    [SerializeField] private float gravityForce;
    [SerializeField] private float fallRate;

    private bool jumpInput;
    private bool isOnGround;
    private bool isJumping;
    private float vertVelocity;

    [SerializeField] private UnityEvent onJump;
    [SerializeField] private UnityEvent onLand;
    [SerializeField] private UnityEvent onHoverStart;
    [SerializeField] private UnityEvent onHoverEnd;
    [SerializeField] private UnityEvent onStep;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }


    // Start is called before the first frame update
    void Start()
    {
        jumpTimeCurrent = jumpTimeMax;
        playerRb.useGravity = false;
    }


    private void FixedUpdate()
    {
        Jump();
        ApplyGravity();
    }

    // Handles isOnGround, and gameOver variables plus collision with the ground and obstacle tags
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpTimeCurrent = jumpTimeMax;
            onLand?.Invoke();
        }
    }

    public void JumpInputOn()
    {
        jumpInput = true;
    }

    public void JumpInputOff()
    {
        jumpInput = false;
    }

    private void Jump()
    {
        if (gameStateKeeper.CurrentGameState == GameState.GAMEACTIVE)
        {

            if (isOnGround && jumpInput)
            {
                vertVelocity = 0;
                playerRb.velocity = Vector3.up * jumpForce;
                isOnGround = false;
                isJumping = true;
                onJump?.Invoke();

            }

            if (isJumping && jumpInput)
            {
                if (jumpTimeCurrent > (jumpTimeMax * jumpTimeThreshold))
                {
                    playerRb.velocity = Vector3.up * jumpForce;
                    jumpTimeCurrent -= Time.deltaTime;

                }

                if (jumpTimeCurrent <= (jumpTimeMax * jumpTimeThreshold))
                {
                    playerRb.velocity = Vector3.up * (jumpForce / 2);
                    jumpTimeCurrent -= Time.deltaTime;

                }

                if (jumpTimeCurrent <= 0)
                {
                    isJumping = false;
                }
            }



            if (!jumpInput)
            {
                isJumping = false;
            }

            if (!isJumping && !isOnGround && jumpInput)
            {
                vertVelocity = vertVelocity - (Time.deltaTime * fallRate);
                playerRb.velocity = new Vector3(0, vertVelocity, 0);
                onHoverStart?.Invoke();

                // if (!sfxEmitterHover.IsPlaying())
                // {
                //     sfxEmitterHover.Play();

                // }
                // else if (sfxEmitterHover.IsPlaying())
                // {
                //     sfxEmitterHover.SetParameter("Fall Velocity", vertVelocity);
                // }



            }

            if (!isJumping && !isOnGround && !jumpInput)
            {
                playerRb.AddForce(new Vector3(0, 0, 0), ForceMode.VelocityChange);
                onHoverEnd?.Invoke();

            }
        }

    }

    public void PlayerStep()
    {
        onStep?.Invoke();
    }

    private void ApplyGravity()
    {
        playerRb.AddForce(new Vector3(0, -gravityForce, 0) * playerRb.mass);
    }

}
