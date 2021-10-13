using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[System.Serializable] public class OnBallMove : UnityEvent<Vector2> { }
[System.Serializable] public class OnBallRotate : UnityEvent<Vector2> { }

public class BallInput_Player : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    private InputActionMap inputActionMap;

    private InputAction ballMove;
    private InputAction ballRotate;

    [SerializeField] private OnBallMove onBallMove;
    [SerializeField] private OnBallRotate onBallRotate;

    private void Awake()
    {
        inputActionMap = inputActionAsset.FindActionMap("Ball");

        ballMove = inputActionMap.FindAction("Move");
        ballRotate = inputActionMap.FindAction("Rotate");
    }

    private void OnEnable()
    {
        ballMove.started += DoBallMoveStart;
        ballMove.canceled += DoBallMoveStop;

        ballRotate.started += DoBallRotateStart;
        ballRotate.canceled += DoBallRotateStop;
    }

    private void OnDisable()
    {
        ballMove.started -= DoBallMoveStart;
        ballMove.canceled -= DoBallMoveStop;

        ballRotate.started -= DoBallRotateStart;
        ballRotate.canceled -= DoBallRotateStop;
    }

    private void DoBallMoveStart(InputAction.CallbackContext context)
    {
        onBallMove?.Invoke(context.ReadValue<Vector2>());
    }

    private void DoBallMoveStop(InputAction.CallbackContext context)
    {
        onBallMove?.Invoke(new Vector2(0, 0));
    }

    private void DoBallRotateStart(InputAction.CallbackContext context)
    {
        onBallRotate?.Invoke(context.ReadValue<Vector2>());
    }

    private void DoBallRotateStop(InputAction.CallbackContext context)
    {
        onBallRotate?.Invoke(new Vector2(0, 0));
    }

}
