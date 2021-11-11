using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 125f;
    [SerializeField] private SOVector2 rotateDirection;
    

    private void FixedUpdate()
    {
        Rotate();
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up, rotateDirection.value.x * rotationSpeed * Time.deltaTime);
    }

}
