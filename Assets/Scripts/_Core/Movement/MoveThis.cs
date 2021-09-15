
using UnityEngine;

public class MoveThis : MonoBehaviour
{
    [SerializeField] private Vector3 speed;

    void Update()
    {
        transform.position += speed;
    }
}
