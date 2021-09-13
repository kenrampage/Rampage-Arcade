using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private bool destroyOnSpawn;
    [SerializeField] private float delay;

    private void OnEnable()
    {
        if(destroyOnSpawn)
        {
            DestroyThisObject();
        }
    }

    public void DestroyThisObject()
    {
        Destroy(gameObject, delay);
    }

}
