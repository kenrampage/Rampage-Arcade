using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.UI;

public class PlayerController4 : MonoBehaviour
{
    [EventRef] public string[] soundEvents;

    public Image powerupTimer;

    public float speed = 5f;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public bool hasPowerUp = false;
    public float powerupStrength = 15f;
    public float bounceStrength = 2f;
    public GameObject powerupIndicator;
    public float powerupDuration = 7;
    public float powerupDurationCurrent;

    private bool isDefeated;
    public float deathHeight;
    public float fadeTime;

    private GameManager gameManager;
    [SerializeField] SpawnManager4 spawnManager4;

    public float forwardInput;

    private float currentSpeed;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
        hasPowerUp = false;
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        currentSpeed = playerRb.velocity.magnitude;

        powerupIndicator.transform.position = transform.position + new Vector3(0, -.5f, 0);



        if (transform.position.y < deathHeight && !isDefeated)
        {
            isDefeated = true;
            LeanTween.alpha(this.gameObject, 0, fadeTime);
        }

        if (transform.position.y <= -10)
        {
            if (gameManager.CurrentGameState == GameState.GAMEACTIVE)
            {
                gameManager.EndLevel();

            }
        }

        if (hasPowerUp)
        {
            powerupDurationCurrent -= Time.deltaTime;
            powerupTimer.fillAmount = powerupDurationCurrent / powerupDuration;

            if (powerupDurationCurrent <= 0)
            {
                PowerupOff();
            }
        }


    }

    private void FixedUpdate()
    {
        if (gameManager.CurrentGameState == GameState.GAMEACTIVE)
        {
            playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        }

    }

    // Upon touching a power up, destroys the powerup then sets HasPowerUp to true
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            spawnManager4.powerupCountCurrent--;
            PowerupOn();
            FMODUnity.RuntimeManager.PlayOneShotAttached(soundEvents[2], gameObject);
        }

    }

    // Upon colliding with enemy while player has power up, launches enemy away from player
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {

            Rigidbody enemyRigidBody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.transform.position - gameObject.transform.position;

            other.rigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

            FMODUnity.RuntimeManager.PlayOneShotAttached(soundEvents[1], gameObject);
            // Debug.Log("Collided with " + other.gameObject.name + " while hasPowerUp =" + hasPowerUp);
        }

        if (other.gameObject.CompareTag("Enemy") && !hasPowerUp)
        {

            Rigidbody enemyRigidBody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.transform.position - gameObject.transform.position;

            other.rigidbody.AddForce(awayFromPlayer * bounceStrength, ForceMode.Impulse);

            FMODUnity.RuntimeManager.PlayOneShotAttached(soundEvents[0], gameObject);
            // Debug.Log("Collided with " + other.gameObject.name + " while hasPowerUp =" + hasPowerUp);
        }

    }

    // // Used as a coroutine to wait a few seconds then turn off power up
    // IEnumerator PowerupCountdownRoutine()
    // {
    //     yield return new WaitForSeconds(7);
    //     powerupIndicator.SetActive(false);
    //     hasPowerUp = false;
    // }

    public void PowerupOn()
    {
        hasPowerUp = true;
        powerupIndicator.SetActive(true);
        powerupDurationCurrent = powerupDuration;
        powerupTimer.fillAmount = 1;

    }

    public void PowerupOff()
    {
        hasPowerUp = false;
        powerupIndicator.SetActive(false);
        powerupDurationCurrent = 0;
        powerupTimer.fillAmount = 0;
        FMODUnity.RuntimeManager.PlayOneShotAttached(soundEvents[3], gameObject);
    }

}
