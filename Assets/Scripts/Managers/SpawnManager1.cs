using UnityEngine;

public class SpawnManager1 : SpawnManager
{

    [SerializeField] private MassSpawnObjects obstacleSpawner;
    [SerializeField] private MassSpawnObjects pickupSpawner;
    [SerializeField] private SpawnObjectsAtLocation playerSpawner;

    private void OnEnable()
    {
        ScoreKeeper.onScoreChanged += HandleScoreChanged;
    }

    private void OnDisable()
    {
        ScoreKeeper.onScoreChanged -= HandleScoreChanged;
    }

    private void HandleScoreChanged(int i)
    {
        ClearPickups();
        SpawnPickups();
        ClearObstacles();
        SpawnObstacles();
    }

    public void SpawnPlayer()
    {
        playerSpawner.SpawnObject(0);
    }

    public void SpawnPickups()
    {
        pickupSpawner.SpawnObjects();
    }   

    public void ClearPickups()
    {
        pickupSpawner.ClearSpawnedObjects();
    }

    public void SpawnObstacles()
    {
        obstacleSpawner.SpawnObjects();
    }

    public void ClearObstacles()
    {
        obstacleSpawner.ClearSpawnedObjects();
    }


}
