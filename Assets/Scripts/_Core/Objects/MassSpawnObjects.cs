using System.Collections.Generic;
using UnityEngine;

public class MassSpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;
    [SerializeField] private List<GameObject> spawnedObjects = new List<GameObject>();
    [SerializeField] private SOInteger objectCountSO;
    [SerializeField] private Collider spawnArea;
    [SerializeField] private float maxScale;
    [SerializeField] private float minScale;
    [SerializeField] int baseNumberToSpawn;
    [SerializeField] int currentNumberToSpawn;

    private void Awake()
    {
        currentNumberToSpawn = baseNumberToSpawn;
        objectCountSO.ResetValue();
    }

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

    public void SpawnObjects()
    {
        for (int i = 0; i < currentNumberToSpawn; i++)
        {
            SpawnRandomObject();
            objectCountSO.IncrementValue();
        }
    }

    public void SpawnObject(int i)
    {
        var spawnedObject = Instantiate(objectsToSpawn[i], GetRandomSpawnLocation(), objectsToSpawn[i].transform.rotation);
        var newScale = Random.Range(minScale, maxScale);

        spawnedObjects.Add(spawnedObject);

        spawnedObject.transform.localScale = new Vector3(newScale, newScale, newScale);

    }

    public void SpawnRandomObject()
    {
        var spawnIndex = GetRandomSpawnIndex();
        var spawnedObject = Instantiate(objectsToSpawn[spawnIndex], GetRandomSpawnLocation(), objectsToSpawn[spawnIndex].transform.rotation);
        var newScale = Random.Range(minScale, maxScale);
        var currentScale = spawnedObject.transform.localScale;
        spawnedObject.transform.localScale = currentScale * newScale;

        spawnedObjects.Add(spawnedObject);

    }

    public void ClearSpawnedObjects()
    {
        foreach (var item in spawnedObjects)
        {
            Destroy(item.gameObject);
        }
        spawnedObjects.Clear();
        objectCountSO.ResetValue();
    }

    public void IncreaseNumberToSpawn(int i)
    {
        currentNumberToSpawn += i;
    }

    public void DecreaseNumberToSpawn(int i)
    {
        currentNumberToSpawn -= i;
    }

    public void SetNumberToSpawn(int i)
    {
        currentNumberToSpawn = i;
    }

    public void IncrementNumberToSpawn()
    {
        currentNumberToSpawn ++;
    }

    public void DecrementNumberToSpawn()
    {
        currentNumberToSpawn --;
    }

    public void RemoveObjectFromList(GameObject gameObject)
    {
        spawnedObjects.Remove(gameObject);
    }

}

