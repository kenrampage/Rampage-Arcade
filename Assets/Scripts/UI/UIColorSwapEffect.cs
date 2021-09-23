using UnityEngine;
using UnityEngine.UI;

public class UIColorSwapEffect : MonoBehaviour
{
    private Color baseColor;
    private Image image;
    [SerializeField] Color newColor;

    private void Awake()
    {
        image = GetComponent<Image>();
        baseColor = image.color;
    }

    public void SetColor()
    {
        image.color = newColor;
    }

    public void ResetColor()
    {
        image.color = baseColor;
    }

}
