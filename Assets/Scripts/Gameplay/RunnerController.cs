using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMODUnity;

public class RunnerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private Animator playerAnim;

    private float vertVelocity;
    public float jumpTimeCurrent;
    public float jumpForce = 10f;
    public float jumpTimeMax;
    public float jumpTimeThreshold;
    public float gravityForce;
    public float fallRate;

    private bool jumpInput;
    private bool isOnGround;
    private bool isJumping;

    [SerializeField] private SOGameStateKeeper gameStateKeeper;
    public StudioEventEmitter sfxEmitterHover;


    [SerializeField] private UnityEvent onJump;
    [SerializeField] private UnityEvent onLand;
    [SerializeField] private UnityEvent onHoverStart;
    [SerializeField] private UnityEvent onHoverEnd;
    [SerializeField] private UnityEvent onPickup;
    [SerializeField] private UnityEvent onStep;
    [SerializeField] private UnityEvent onCrash;


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        jumpTimeCurrent = jumpTimeMax;
        playerRb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpInput = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpInput = false;
        }

        if (gameStateKeeper.CurrentGameState != GameState.GAMEACTIVE)
        {
            sfxEmitterHover.Stop();
        }


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
            playerAnim.SetBool("Grounded", true);

            if (gameStateKeeper.CurrentGameState == GameState.GAMEACTIVE)
            {
                playerAnim.SetBool("IsRunning", true);

            }

            onLand?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameStateKeeper.CurrentGameState == GameState.GAMEACTIVE)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {

                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                sfxEmitterHover.Stop();
                onCrash?.Invoke();

            }

            if (other.gameObject.CompareTag("Pickup"))
            {
                other.GetComponent<PointValue>().UpdateScore();

                Destroy(other.gameObject);
                onPickup?.Invoke();
            }
        }
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
                playerAnim.SetTrigger("Jump_trig");
                playerAnim.SetBool("IsRunning", false);
                playerAnim.SetBool("Grounded", false);
                onJump?.Invoke();

            }

            if (isJumping && jumpInput)
            {
                if (jumpTimeCurrent > (jumpTimeMax * jumpTimeThreshold))
                {
                    playerAnim.SetTrigger("Jump_trig");
                    playerRb.velocity = Vector3.up * jumpForce;
                    jumpTimeCurrent -= Time.deltaTime;

                }

                if (jumpTimeCurrent <= (jumpTimeMax * jumpTimeThreshold))
                {
                    playerAnim.SetTrigger("Jump_trig");
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
                playerAnim.SetTrigger("Jump_trig");
                vertVelocity = vertVelocity - (Time.deltaTime * fallRate);
                playerRb.velocity = new Vector3(0, vertVelocity, 0);
                onHoverStart?.Invoke();

                if (!sfxEmitterHover.IsPlaying())
                {
                    sfxEmitterHover.Play();

                }
                else if (sfxEmitterHover.IsPlaying())
                {
                    sfxEmitterHover.SetParameter("Fall Velocity", vertVelocity);
                }



            }

            if (!isJumping && !isOnGround && !jumpInput)
            {
                playerRb.AddForce(new Vector3(0, 0, 0), ForceMode.VelocityChange);

                if (sfxEmitterHover.IsPlaying())
                {
                    sfxEmitterHover.Stop();
                }

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
