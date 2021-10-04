using UnityEngine;

public class SpawnObjectInArea : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;
    [SerializeField] private Collider spawnArea;

    private Vector3 GetRandomSpawnLocation()
    {
        Vector3 spawnRange = spawnArea.bounds.extents;
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRange.x, spawnRange.x), 0, Random.Range(-spawnRange.z, spawnRange.z));
        return spawnPos;
    }

    private int GetRandomSpawnIndex()
    {
        var spawnIndex = Random.Range(0, objectsToSpawn.Length);
        return spawnIndex;
    }

    [ContextMenu("Spawn Random Object")]
    public void SpawnRandomObject()
    {
        var spawnIndex = GetRandomSpawnIndex();
        var spawnedObject = Instantiate(objectsToSpawn[spawnIndex], GetRandomSpawnLocation(), objectsToSpawn[spawnIndex].transform.rotation);
    }



}
