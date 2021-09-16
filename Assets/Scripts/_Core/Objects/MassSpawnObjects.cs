using System.Collections.Generic;
using UnityEngine;

public class MassSpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;
    [SerializeField] private List<GameObject> spawnedObjects = new List<GameObject>();
    [SerializeField] private Collider spawnArea;
    [SerializeField] private float maxScale;
    [SerializeField] private float minScale;
    [SerializeField] int baseNumberToSpawn;
    [SerializeField] int currentNumberToSpawn;

    private void Awake()
    {
        currentNumberToSpawn = baseNumberToSpawn;
    }

    private Vector3 GetRandomSpawnLocation()
    {
        Vector3 _spawnRange = spawnArea.bounds.extents;
        Vector3 _spawnPos = new Vector3(Random.Range(-_spawnRange.x, _spawnRange.x), 0, Random.Range(-_spawnRange.z, _spawnRange.z));
        return _spawnPos;
    }

    private int GetRandomSpawnIndex()
    {
        var _spawnIndex = Random.Range(0, objectsToSpawn.Length);
        return _spawnIndex;
    }

    public void SpawnObjects()
    {
        for (int i = 0; i < currentNumberToSpawn; i++)
        {
            SpawnRandomObject();
        }
    }

    public void SpawnObject(int i)
    {
        var _spawnedObject = Instantiate(objectsToSpawn[i], GetRandomSpawnLocation(), objectsToSpawn[i].transform.rotation);
        var _newScale = Random.Range(minScale, maxScale);

        spawnedObjects.Add(_spawnedObject);

        _spawnedObject.transform.localScale = new Vector3(_newScale, _newScale, _newScale);

    }

    public void SpawnRandomObject()
    {
        var _spawnIndex = GetRandomSpawnIndex();
        var _spawnedObject = Instantiate(objectsToSpawn[_spawnIndex], GetRandomSpawnLocation(), objectsToSpawn[_spawnIndex].transform.rotation);
        var _newScale = Random.Range(minScale, maxScale);
        var _currentScale = _spawnedObject.transform.localScale;
        _spawnedObject.transform.localScale = _currentScale * _newScale;

        spawnedObjects.Add(_spawnedObject);

    }

    public void ClearSpawnedObjects()
    {
        foreach (var item in spawnedObjects)
        {
            Destroy(item.gameObject);
        }
        spawnedObjects.Clear();
    }

    public void IncreaseNumberToSpawn(int i)
    {
        currentNumberToSpawn += i;
    }

    public void DecreaseNumberToSpawn(int i)
    {
        currentNumberToSpawn -= i;
    }

    public void UpdateNumberToSpawn(int i)
    {
        currentNumberToSpawn = i;
    }

}

