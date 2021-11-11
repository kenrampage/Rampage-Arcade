using UnityEngine;
using UnityEngine.InputSystem;

public class BallInput_Player : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    [SerializeField] private SOVector2 moveDirection;
    [SerializeField] private SOVector2 rotateDirection;

    private InputActionMap inputActionMap;

    private InputAction ballMoveDirection;
    private InputAction ballRotateDirection;

    private void Awake()
    {
        inputActionMap = inputActionAsset.FindActionMap("Ball");

        ballMoveDirection = inputActionMap.FindAction("Move");
        ballRotateDirection = inputActionMap.FindAction("Rotate");
    }

    private void Update()
    {
        if (inputActionMap.enabled)
        {
            GetMoveDirection();
            GetRotateDirection();
        }
    }

    private void GetMoveDirection()
    {
        moveDirection.value = new Vector3(ballMoveDirection.ReadValue<Vector2>().x, ballMoveDirection.ReadValue<Vector2>().y, 0);
    }

    private void GetRotateDirection()
    {
        rotateDirection.value = new Vector3(ballRotateDirection.ReadValue<Vector2>().x, ballRotateDirection.ReadValue<Vector2>().y, 0);

    }

}
