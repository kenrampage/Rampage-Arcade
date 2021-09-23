using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Vector3 obstacleRangeMin;
    public Vector3 obstacleRangeMax;
    public float obstacleSizeMin;
    public float obstacleSizeMax;
    // public float obstacleSpawnIntervalStartMax = 1.5f;
    // public float obstacleSpawnIntervalStartMin = 1.5f;
    public float obstacleIntervalMax;
    public float obstacleIntervalMin;
    public float obstacleIntervalMultiplierStart = 1f;
    public float obstacleIntervalMultiplier;
    public float obstacleIntervalMultiplierMin;
    public float obstacleIntervalMultiplierDecrease;
    private float obstacleTimer;
    private Vector3 obstaclePos;

    public GameObject[] pickupPrefabs;
    public Vector3 pickupRangeMin;
    public Vector3 pickupRangeMax;
    // public float pickupSpawnIntervalStartMax = 1.5f;
    // public float pickupSpawnIntervalStartMin = 1.5f;
    public float pickupIntervalMax;
    public float pickupIntervalMin;
    public float pickupIntervalMultiplierStart = 1f;
    public float pickupIntervalMultiplier;
    public float pickupIntervalMultiplierMin;
    public float pickupIntervalMultiplierDecrease;
    private float pickupTimer;
    private Vector3 pickupPos;

    [SerializeField] private SOGameStateKeeper gameStateKeeper;
    private ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Start is called before the first frame update
    void Start()
    {

        InitializeSpawnTimers();

    }

    // Update is called once per frame
    void Update()
    {

        if (gameStateKeeper.CurrentGameState == GameState.GAMEACTIVE)
        {
            obstacleTimer -= Time.deltaTime;
            pickupTimer -= Time.deltaTime;


            if (obstacleTimer <= 0)
            {
                SpawnObstacle();
                if (obstacleIntervalMultiplier > obstacleIntervalMultiplierMin)
                {
                    obstacleIntervalMultiplier = obstacleIntervalMultiplierStart - (scoreKeeper.Score * obstacleIntervalMultiplierDecrease);
                }
                obstacleTimer = Random.Range(obstacleIntervalMin, obstacleIntervalMax) * obstacleIntervalMultiplier;
            }

            if (pickupTimer <= 0)
            {
                SpawnPickup();
                if (pickupIntervalMultiplier > pickupIntervalMultiplierMin)
                {
                    pickupIntervalMultiplier = pickupIntervalMultiplierStart - (scoreKeeper.Score * pickupIntervalMultiplierDecrease);
                }
                pickupTimer = Random.Range(pickupIntervalMin, pickupIntervalMax) * pickupIntervalMultiplier;
            }
        }

    }

    // Chooses a random entry from the obstaclePrefabs array then spawns that animal at the location set 
    // by the variables
    void SpawnObstacle()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        GenerateObstacleSpawnPos();

        GameObject obstacle = Instantiate(obstaclePrefabs[obstacleIndex], obstaclePos, obstaclePrefabs[obstacleIndex].transform.rotation);
        float newScale = Random.Range(obstacleSizeMin, obstacleSizeMax);
        obstacle.transform.localScale = new Vector3(newScale, newScale, newScale);

    }

    void GenerateObstacleSpawnPos()
    {
        obstaclePos = new Vector3(Random.Range(obstacleRangeMin.x, obstacleRangeMax.x), Random.Range(obstacleRangeMin.y, obstacleRangeMax.y), Random.Range(obstacleRangeMin.z, obstacleRangeMax.z));

    }

    void SpawnPickup()
    {
        int pickupIndex = Random.Range(0, pickupPrefabs.Length);
        GeneratePickupSpawnPos();

        Instantiate(pickupPrefabs[pickupIndex], pickupPos, pickupPrefabs[pickupIndex].transform.rotation);

    }

    void GeneratePickupSpawnPos()
    {
        pickupPos = new Vector3(Random.Range(pickupRangeMin.x, pickupRangeMax.x), Random.Range(pickupRangeMin.y, pickupRangeMax.y), Random.Range(pickupRangeMin.z, pickupRangeMax.z));

    }

    void InitializeSpawnTimers()
    {

        obstacleIntervalMultiplier = obstacleIntervalMultiplierStart;
        pickupIntervalMultiplier = pickupIntervalMultiplierStart;

        obstacleTimer = Random.Range(obstacleIntervalMin, obstacleIntervalMax) * obstacleIntervalMultiplier;
        pickupTimer = Random.Range(pickupIntervalMin, pickupIntervalMax) * pickupIntervalMultiplier;


    }


}
