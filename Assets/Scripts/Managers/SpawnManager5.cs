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
            Instantiate(targets[index]);

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
}
