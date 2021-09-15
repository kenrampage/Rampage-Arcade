using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;
    [SerializeField] private Vector3 spawnOffset;

    public void SpawnObject(int index)
    {
        Instantiate(objectsToSpawn[index], transform.position + spawnOffset, objectsToSpawn[index].transform.rotation);
    }

    public void SpawnAllObjects()
    {
        for (int i = 0; i < objectsToSpawn.Length; i++)
        {
            SpawnObject(i);
        }
    }
    
}
