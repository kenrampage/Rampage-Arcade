using UnityEngine;
using UnityEngine.UI;

public class SelectButtonOnEnable : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.Select();
    }
}
