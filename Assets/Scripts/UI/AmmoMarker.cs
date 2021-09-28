using UnityEngine;

public class AmmoMarker : MonoBehaviour
{
    [SerializeField] private SOAmmoKeeper ammo;

    public GameObject[] ammoMarkers;

    private void OnEnable()
    {
        ammo.onAmmoChanged += UpdateAmmoMarkers;
    }

    private void OnDisable()
    {
        ammo.onAmmoChanged -= UpdateAmmoMarkers;
    }

    private void UpdateAmmoMarkers(int ammoValue)
    {
        foreach (var ammoMarker in ammoMarkers)
        {
            ammoMarker.gameObject.SetActive(false);
        }

        for (int i = 0; i < ammoValue; i++)
        {
            ammoMarkers[i].gameObject.SetActive(true);
        }
    }
}
