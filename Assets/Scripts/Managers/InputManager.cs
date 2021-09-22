using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;

    public void EnableActionMap(string actionMapName)
    {
        inputActionAsset.FindActionMap(actionMapName).Enable();
        print(inputActionAsset.FindActionMap(actionMapName).name + " Action Map Enabled!");
    }

    public void DisableActionMap(string actionMapName)
    {
        inputActionAsset.FindActionMap(actionMapName).Disable();
        print(inputActionAsset.FindActionMap(actionMapName).name + " Action Map Disabled!");
    }

}
