using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 125f;
    private float rotateInput;

    private void FixedUpdate()
    {
        Rotate();
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up, rotateInput * rotationSpeed * Time.deltaTime);
    }

    public void SetRotateInput(Vector2 value)
    {
        rotateInput = value.x;
    }
}
