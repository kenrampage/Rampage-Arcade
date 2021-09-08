using UnityEngine;
using UnityEngine.UI;

public class UIMenuThumbnailSwitcher : MonoBehaviour
{

    [SerializeField] private Texture thumbnailTexture;
    [SerializeField] private RawImage thumbnailTarget;

    private Texture originalThumbnailTexture;
    

    // Start is called before the first frame update
    void Start()
    {
        originalThumbnailTexture = null;
        thumbnailTarget.color = new Color(0, 0, 0, 0);
    }

    public void SetThumbnailImage()
    {
        thumbnailTarget.color = new Color(1, 1, 1, 1);
        thumbnailTarget.texture = thumbnailTexture;
    }

    public void ResetThumbnailImage()
    {
        thumbnailTarget.texture = originalThumbnailTexture;
        thumbnailTarget.color = new Color(0, 0, 0, 0);
    }

}
