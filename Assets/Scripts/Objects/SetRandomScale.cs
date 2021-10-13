using UnityEngine;

public class SetRandomScale : MonoBehaviour
{
    [SerializeField] private bool scaleOnAwake;
    [SerializeField] private float minScaleMultiplier;
    [SerializeField] private float maxScaleMultiplier;

    private void Awake()
    {
        if(scaleOnAwake)
        {
            RandomizeScale();
        }
    }

    public void RandomizeScale()
    {
        float scaleMultiplier = Random.Range(minScaleMultiplier, maxScaleMultiplier);
        transform.localScale = transform.localScale * scaleMultiplier;
    }


}
