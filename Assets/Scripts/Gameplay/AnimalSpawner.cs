using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public Vector3 spawnRangeMin;
    public Vector3 spawnRangeMax;
    public float spawnIntervalStart = 1.5f;
    public float spawnIntervalMin;
    public float spawnIntervalCurrent;
    public float spawnIntervalDecrease;
    private float spawnTimer;

    private Vector3 spawnPos;

    [SerializeField] private SOGameStateKeeper gameStateKeeper;
    private ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        spawnIntervalCurrent = spawnIntervalStart;
        spawnTimer = spawnIntervalCurrent;

    }

    // Update is called once per frame
    void Update()
    {

        if (gameStateKeeper.CurrentGameState == GameState.GAMEACTIVE)
        {
            spawnTimer -= Time.deltaTime;
            // print(spawnTimer);

            if (spawnTimer <= 0)
            {
                SpawnRandomAnimal();
                if (spawnIntervalCurrent > spawnIntervalMin)
                {
                    spawnIntervalCurrent = spawnIntervalStart - (scoreKeeper.Score * spawnIntervalDecrease);
                }
                spawnTimer = spawnIntervalCurrent;
            }
        }

    }

    // Chooses a random entry from the animalPrefabs array then spawns that animal at the location set 
    // by the variables
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        GenerateSpawnPos();

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void GenerateSpawnPos()
    {
        spawnPos = new Vector3(Random.Range(spawnRangeMin.x, spawnRangeMax.x), 0, Random.Range(spawnRangeMin.z, spawnRangeMax.z));

    }
}
