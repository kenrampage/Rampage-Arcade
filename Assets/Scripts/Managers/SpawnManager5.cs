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

    private GameManager5 gameManager5;

    // Start is called before the first frame update
    void Start()
    {
        gameManager5 = GameManager5.Instance;
    }



    IEnumerator SpawnTarget()
    {
        while (gameManager5.gameIsActive)
        {
            yield return new WaitForSeconds(spawnRateCurrent);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

            if(spawnRateCurrent > spawnRateMin)
            {
                spawnRateCurrent -= waveRate;
                print("Current Rate: " + spawnRateCurrent);
            }
            
        }
    }

    public void StartSpawning(int difficulty)
    {
        spawnRateCurrent = spawnRateBase / difficulty;
        spawnRateMin = (spawnRateBase / difficulty) / 3f;

        StartCoroutine(SpawnTarget());
    }
}
