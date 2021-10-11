using UnityEngine;

public class UIToggleInputPrompts : MonoBehaviour
{

    [SerializeField] private GameObject buttonPrompts;
    [SerializeField] private GameObject clickPrompts;
    [SerializeField] private GameObject promptsContainer;

    public void PromptsOff()
    {
        promptsContainer.SetActive(false);
    }

    public void PromptsOn()
    {
        promptsContainer.SetActive(true);

    }

    public void ButtonsOn()
    {
        buttonPrompts.SetActive(true);
        clickPrompts.SetActive(false);
    }

    public void ClickOn()
    {
        buttonPrompts.SetActive(false);
        clickPrompts.SetActive(true);
    }

    public void OnSelect()
    {
        PromptsOn();
        ButtonsOn();
    }

    public void OnDeselect()
    {
        PromptsOff();
    }

    public void OnPointerEnter()
    {
        ClickOn();
    }

    public void OnPointerExit()
    {
        ButtonsOn();
    }


}
