
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private Vector3 speed;

    void Update()
    {
        transform.position += speed;
    }
}
