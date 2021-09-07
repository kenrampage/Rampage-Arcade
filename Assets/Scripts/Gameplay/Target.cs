using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager5 gameManager5;
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


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager5 = GameManager5.Instance;

        transform.position = RandomSpawnPos();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());

        // sfxPlayer = gameManager5.sfxPlayer;

    }


    // Destroys this game object on mouse down
    private void OnMouseDown()
    {
        if (gameManager5.gameIsActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager5.UpdateScore(pointValue);
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
    //         gameManager5.EndGame();
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
