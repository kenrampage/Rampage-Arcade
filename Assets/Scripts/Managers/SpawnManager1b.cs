using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnManager1b : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] pickups;
    public GameObject playerPrefab;
    public GameObject player;
    public GameObject playerSpawnPoint;
    public GameObject spawnArea;
    public Vector3 spawnRange;
    public Vector3 spawnPos;
    public Vector3 tempPos;
    public float spawnBuffer;

    public float maxScale;
    public float minScale;

    private GameManager gameManager;

    public int startObstacles;
    public int currentObstacles;
    public int additionalObstacles;

    public List<GameObject> spawnedObstacles = new List<GameObject>();

    private void OnEnable()
    {
        CarControllerC.onPickup += RespawnLevelObjects;
    }

    private void OnDisable()
    {
        CarControllerC.onPickup -= RespawnLevelObjects;
    }

    private void Start()
    {
        // gameManager = GameManager.Instance;
        currentObstacles = startObstacles;
        SpawnLevelObjects();
    }

    public void SpawnLevelObjects()
    {
        // print("Level Objects Spawned!");
        if (player != null)
        {
            Destroy(player.gameObject);
            player = null;

        }

        player = Instantiate(playerPrefab, playerSpawnPoint.transform.position, playerSpawnPoint.transform.rotation);

        SpawnObstacles();
        SpawnPickups();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SpawnObstacles();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RemoveObstacles();
        }

    }

    public void RespawnLevelObjects()
    {
        currentObstacles += additionalObstacles;
        RemoveObstacles();
        SpawnObstacles();
        SpawnPickups();

        print("Objects Respawned!");
    }

    public void GetRandomSpawnLocation()
    {
        spawnRange = spawnArea.GetComponent<BoxCollider>().bounds.extents;
        spawnPos = new Vector3(UnityEngine.Random.Range(-spawnRange.x, spawnRange.x), 0, UnityEngine.Random.Range(-spawnRange.z, spawnRange.z));

    }


    public void SpawnObstacles()
    {
        for (int i = 0; i < currentObstacles; i++)
        {
            SpawnObstacle(UnityEngine.Random.Range(0, obstacles.Length));
        }

    }

    public void SpawnObstacle(int i)
    {
        GetRandomSpawnLocation();

        GameObject spawnedObject = Instantiate(obstacles[i], spawnPos, obstacles[i].transform.rotation);
        spawnedObstacles.Add(spawnedObject);
        // print("Obstacle " + (spawnedObstacles.Count - 1) + " spawned!");
        float newScale = UnityEngine.Random.Range(minScale, maxScale);
        spawnedObject.transform.localScale = new Vector3(newScale, newScale, newScale);

    }

    public void RemoveObstacles()
    {
        foreach (var item in spawnedObstacles)
        {
            Destroy(item.gameObject);

        }

        spawnedObstacles.Clear();
    }


    public void SpawnPickups()
    {
        for (int i = 0; i < pickups.Length; i++)
        {
            GetRandomSpawnLocation();
            Instantiate(pickups[i], spawnPos, pickups[i].transform.rotation);
            print("Bolt Spawned!");
        }
    }

}
