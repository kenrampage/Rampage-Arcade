using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    private SoundPlayer2D sfxPlayer;
    public int sfxIndex;

    public float minForce = 12;
    public float maxForce = 16;
    public float maxTorque = 10;
    public float xRange = 4;
    public float ySpawnPos = -2;

    public int pointValue;
    public GameObject pointPrefab;

    private ScoreKeeper scoreKeeper;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
        transform.position = RandomSpawnPos();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());

        // sfxPlayer = gameManager.sfxPlayer;

    }


    // Destroys this game object on mouse down
    private void OnMouseDown()
    {
        if (gameManager.CurrentGameState == GameState.GAMEACTIVE)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            scoreKeeper.UpdateScore(pointValue);
            Instantiate(pointPrefab, transform.position, pointPrefab.transform.rotation);
            // sfxPlayer.PlaySoundEvent(sfxIndex);
        }

    }

    // // Destroys this game object on collision with any trigger
    // private void OnTriggerEnter(Collider other)
    // {
    //     Destroy(gameObject);

    //     if (!gameObject.CompareTag("Bad"))
    //     {
    //         gameManager.EndGame();
    //     }

    // }

    // Returns random UP force in Vector3
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);

    }

    // Returns random torque as float values
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // Returns random spawn positions in Vector3
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
    }
}
