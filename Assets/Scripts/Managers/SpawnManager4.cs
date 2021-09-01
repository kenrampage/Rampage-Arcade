using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager4 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public float spawnRange = 9f;
    public int enemyCount;
    public int powerupCountCurrent;
    public int powerupCountTarget;
    public int waveNumber = 1;

    private GameManager4 gameManager4;

    // Start is called before the first frame update
    void Start()
    {
        gameManager4 = GameManager4.Instance;
        SpawnWave(waveNumber);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            
            print("Powerup # Target: " + powerupCountTarget);
            SpawnWave(waveNumber);
        }
    }

    // Generates random positions within the spawn range and returns the Vector3 value
    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }


    // Spawns the requested number of enemies
    void SpawnWave(int enemiesToSpawn)
    {
        powerupCountTarget = Mathf.RoundToInt(waveNumber / 3) + 1;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

        }

        if (powerupCountCurrent < powerupCountTarget)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            powerupCountCurrent++;

            for (int i = powerupCountCurrent; i < powerupCountTarget; i++)
            {
                Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
                powerupCountCurrent++;
            }
        }

    }


}

