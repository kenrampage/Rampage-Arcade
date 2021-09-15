using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int currentAmmo;
    public int maxAmmo;

    private void Start()
    {
        ResetAmmo();
    }

    public void DecreaseAmmo()
    {
        currentAmmo--;
    }

    public void ResetAmmo()
    {
        currentAmmo = maxAmmo;
    }
}
