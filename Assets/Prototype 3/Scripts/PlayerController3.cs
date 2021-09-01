using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayerController3 : MonoBehaviour
{

    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public ParticleSystem floatParticle;
    public ParticleSystem pickupParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private float vertVelocity;
    public float jumpTimeCurrent;
    public float jumpForce = 10f;
    public float jumpTimeMax;
    public float jumpTimeThreshold;
    public float gravity;
    public float fallRate;

    private bool jumpInput;
    private bool isOnGround;
    private bool isJumping;

    private GameManager3 gameManager3;

    public float sfxFallRate;

    public StudioEventEmitter sfxEmitterHover;

    // Start is called before the first frame update
    void Start()
    {

        jumpTimeCurrent = jumpTimeMax;
        gameManager3 = GameManager3.Instance;

        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        // print(Physics.gravity);
        Physics.gravity = new Vector3(0, -gravity, 0);
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

        if (!gameManager3.gameIsActive)
        {
            sfxEmitterHover.Stop();
        }


    }

    private void FixedUpdate()
    {
        Jump();
    }

    // Handles isOnGround, and gameOver variables plus collision with the ground and obstacle tags
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpTimeCurrent = jumpTimeMax;
            playerAnim.SetBool("Grounded", true);

            floatParticle.Stop();

            if (gameManager3.gameIsActive)
            {
                StartRunning();
            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager3.gameIsActive)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {

                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                Debug.Log("Game Over!");
                explosionParticle.Play();
                sfxEmitterHover.Stop();
                // gameManager3.sfxPlayer.PlaySoundEvent(6);
                dirtParticle.Stop();
                // playerAudio.PlayOneShot(crashSound, 1f);
                gameManager3.EndGame();

            }

            if (other.gameObject.CompareTag("Pickup"))
            {

                pickupParticle.Play();

            }
        }
    }


    private void Jump()
    {

        if (isOnGround && jumpInput)
        {
            vertVelocity = 0;
            // playerRb.AddForce(Vector3.up * (jumpForce), ForceMode.VelocityChange);
            playerRb.velocity = Vector3.up * jumpForce;
            isOnGround = false;
            isJumping = true;
            playerAnim.SetTrigger("Jump_trig");
            StopRunning();
            playerAnim.SetBool("Grounded", false);
            gameManager3.sfxPlayer.PlaySoundEvent(4);
            // dirtParticle.Stop();

        }

        if (isJumping && jumpInput)
        {
            if (jumpTimeCurrent > (jumpTimeMax * jumpTimeThreshold))
            {
                playerAnim.SetTrigger("Jump_trig");
                // playerRb.AddForce(Vector3.up * (jumpForce), ForceMode.VelocityChange);
                playerRb.velocity = Vector3.up * jumpForce;
                jumpTimeCurrent -= Time.deltaTime;

            }

            if (jumpTimeCurrent <= (jumpTimeMax * jumpTimeThreshold))
            {
                playerAnim.SetTrigger("Jump_trig");
                // playerRb.AddForce(Vector3.up * (jumpForce / 2), ForceMode.VelocityChange);
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



            // playerRb.AddForce(new Vector3(0, vertVelocity, 0), ForceMode.VelocityChange);
            playerRb.velocity = new Vector3(0, vertVelocity, 0);
            floatParticle.Play();

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
            // playerRb.velocity = Vector3.zero;
            playerRb.AddForce(new Vector3(0, 0, 0), ForceMode.VelocityChange);
            floatParticle.Stop();

            if (sfxEmitterHover.IsPlaying())
            {
                sfxEmitterHover.Stop();
            }

        }

    }

    public void StartRunning()
    {
        playerAnim.SetBool("IsRunning", true);
        dirtParticle.Play();
    }

    public void StopRunning()
    {
        playerAnim.SetBool("IsRunning", false);
        dirtParticle.Stop();
    }

}
