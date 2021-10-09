using UnityEngine;

public class SpawnObjectInArea : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;
    [SerializeField] private Collider spawnArea;

    private Vector3 GetRandomSpawnLocation()
    {
        Vector3 spawnRange = spawnArea.bounds.extents;

        Vector3 spawnPos = new Vector3
        (
        Random.Range(-spawnRange.x + spawnArea.bounds.center.x, spawnRange.x + spawnArea.bounds.center.x) + spawnArea.gameObject.transform.position.x,
        Random.Range(-spawnRange.y + spawnArea.bounds.center.y, spawnRange.y + spawnArea.bounds.center.y) + spawnArea.gameObject.transform.position.y,
        Random.Range(-spawnRange.z + spawnArea.bounds.center.z, spawnRange.z + spawnArea.bounds.center.z) + spawnArea.gameObject.transform.position.z
        );
        print(spawnPos);
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
