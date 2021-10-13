using UnityEngine;

public class SpawnObjectsAtLocation : MonoBehaviour
{
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private GameObject[] objectsToSpawn;

    public void SpawnObject(int i)
    {
        Instantiate(objectsToSpawn[i], spawnLocation.position, objectsToSpawn[i].transform.rotation);
    }

    public void SpawnAllObjects()
    {
        for (int i = 0; i < objectsToSpawn.Length; i++)
        {
            SpawnObject(i);
        }
    }

}
