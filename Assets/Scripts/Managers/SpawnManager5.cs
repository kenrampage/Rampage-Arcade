using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager5 : MonoBehaviour
{

    public List<GameObject> targets;
    public float spawnRateBase = 2f;
    public float spawnRateCurrent;
    public float spawnRateMin;
    public float waveRate;

    public float minForce = 12;
    public float maxForce = 16;
    public float maxTorque = 10;
    public float xRange = 4;
    public float ySpawnPos = -2;


    private GameManager gameManager;
    [SerializeField] private DifficultyKeeper difficultyKeeper;

    private void Awake()
    {
        difficultyKeeper = FindObjectOfType<DifficultyKeeper>();
        gameManager = FindObjectOfType<GameManager>();
    }

    IEnumerator SpawnTarget()
    {
        while (gameManager.CurrentGameState == GameState.GAMEACTIVE)
        {
            yield return new WaitForSeconds(spawnRateCurrent);
            int index = Random.Range(0, targets.Count);
            var targetRb = Instantiate(targets[index]).GetComponent<Rigidbody>();
            transform.position = RandomSpawnPos();
            targetRb.AddForce(RandomForce(), ForceMode.Impulse);
            targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());

            if (spawnRateCurrent > spawnRateMin)
            {
                spawnRateCurrent -= waveRate;
                print("Current Rate: " + spawnRateCurrent);
            }

        }
    }

    public void StartSpawning()
    {
        spawnRateCurrent = spawnRateBase / difficultyKeeper.difficulty;
        spawnRateMin = (spawnRateBase / difficultyKeeper.difficulty) / 3f;

        StartCoroutine(SpawnTarget());
    }


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
