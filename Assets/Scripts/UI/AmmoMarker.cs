using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoMarker : MonoBehaviour
{
    // private GameManager2 gameManager2;

    private Ammo ammo;

    public GameObject[] ammoMarkers;

    public int ammoValue;

    private void Awake()
    {
        ammo = FindObjectOfType<Ammo>();
    }

    private void Update()
    {
        ammoValue = ammo.currentAmmo;

        switch (ammoValue)
        {
            case 8:
                for (int i = 0; i < ammoMarkers.Length; i++)
                {
                    ammoMarkers[i].gameObject.SetActive(true);
                }
                break;

            case 7:
                if (ammoMarkers[ammoValue].gameObject.activeSelf)
                {
                    ammoMarkers[ammoValue].gameObject.SetActive(false);
                }

                break;

            case 6:
                if (ammoMarkers[ammoValue].gameObject.activeSelf)
                {
                    ammoMarkers[ammoValue].gameObject.SetActive(false);
                }
                break;

            case 5:
                if (ammoMarkers[ammoValue].gameObject.activeSelf)
                {
                    ammoMarkers[ammoValue].gameObject.SetActive(false);
                }
                break;

            case 4:
                if (ammoMarkers[ammoValue].gameObject.activeSelf)
                {
                    ammoMarkers[ammoValue].gameObject.SetActive(false);
                }
                break;

            case 3:
                if (ammoMarkers[ammoValue].gameObject.activeSelf)
                {
                    ammoMarkers[ammoValue].gameObject.SetActive(false);
                }
                break;

            case 2:
                if (ammoMarkers[ammoValue].gameObject.activeSelf)
                {
                    ammoMarkers[ammoValue].gameObject.SetActive(false);
                }
                break;

            case 1:
                if (ammoMarkers[ammoValue].gameObject.activeSelf)
                {
                    ammoMarkers[ammoValue].gameObject.SetActive(false);
                }
                break;

            case 0:
                if (ammoMarkers[ammoValue].gameObject.activeSelf)
                {
                    ammoMarkers[ammoValue].gameObject.SetActive(false);
                }
                break;

            default:
                break;
        }
    }


}
