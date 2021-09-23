using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    [SerializeField] private Button targetButton;

    public void SelectTargetButton()
    {
        targetButton.Select();
    }
    
}
