using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[System.Serializable] public class OnTopDownMove : UnityEvent<Vector2> { }

public class TopDownInputPlayer : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    private InputActionMap inputActionMap;

    private InputAction topDownMove;
    private InputAction topDownFire;
    private InputAction topDownReload;

    [SerializeField] private OnTopDownMove onTopDownMove;
    [SerializeField] private UnityEvent onTopDownFire;
    [SerializeField] private UnityEvent onTopDownReload;

    private void Awake()
    {
        inputActionMap = inputActionAsset.FindActionMap("TopDownShooter");

        topDownMove = inputActionMap.FindAction("Move");
        topDownFire = inputActionMap.FindAction("Fire");
        topDownReload = inputActionMap.FindAction("Reload");
    }

    private void OnEnable()
    {
        topDownMove.started += DoTopDownMoveStart;
        topDownMove.canceled += DoTopDownMoveStop;
        topDownFire.performed += DoTopDownFire;
        topDownReload.performed += DoTopDownReload;
    }

    private void OnDisable()
    {
        topDownMove.started -= DoTopDownMoveStart;
        topDownMove.canceled -= DoTopDownMoveStop;
        topDownFire.performed -= DoTopDownFire;
        topDownReload.performed -= DoTopDownReload;
    }

    private void DoTopDownMoveStart(InputAction.CallbackContext context)
    {
        onTopDownMove?.Invoke(context.ReadValue<Vector2>());
    }

    private void DoTopDownMoveStop(InputAction.CallbackContext context)
    {
        onTopDownMove?.Invoke(new Vector2(0, 0));
    }

    private void DoTopDownFire(InputAction.CallbackContext context)
    {
        onTopDownFire?.Invoke();
    }

    private void DoTopDownReload(InputAction.CallbackContext context)
    {
        onTopDownReload?.Invoke();
    }

}
