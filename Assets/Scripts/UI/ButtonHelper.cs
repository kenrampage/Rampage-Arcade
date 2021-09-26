using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonHelper : MonoBehaviour
{
    [SerializeField] private bool firstButton;

    [SerializeField] private UnityEvent onFirstSelect;
    [SerializeField] private UnityEvent onSelect;
    [SerializeField] private UnityEvent onDeselect;
    [SerializeField] private UnityEvent onSubmit;

    private Button button;
    private bool firstSelect = false;

    private void Awake()
    {
        button = GetComponent<Button>();
        if(firstButton)
        {
            SelectButton();
            DoSelect();
        }
    }

    public void DoSelect()
    {
        if (firstSelect)
        {
            firstSelect = false;
            onFirstSelect?.Invoke();

        }
        else
        {
            onSelect?.Invoke();
        }
    }

    public void DoDeselect()
    {
        onDeselect?.Invoke();
    }

    public void DoSubmit()
    {
        onSubmit?.Invoke();
    }

    public void SelectButton()
    {
        button.Select();
    }

    public void SetAsFirstButton()
    {
        firstButton = true;
        firstSelect = true;
    }

}
