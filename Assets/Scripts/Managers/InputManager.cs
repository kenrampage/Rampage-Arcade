using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;

    public void EnableActionMap(string actionMapName)
    {
        inputActionAsset.FindActionMap(actionMapName).Enable();
    }

    public void DisableActionMap(string actionMapName)
    {
        inputActionAsset.FindActionMap(actionMapName).Disable();
    }

}
