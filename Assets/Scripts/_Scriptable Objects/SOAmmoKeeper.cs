using UnityEngine;
using System;

[CreateAssetMenu(fileName = "AmmoKeeper", menuName = "Rampage Arcade/SOAmmoKeeper")]
public class SOAmmoKeeper : ScriptableObject
{
    public Action<int> onAmmoChanged;

    public int currentAmmo;
    [SerializeField] private int maxAmmo;

    public void DecrementAmmo()
    {
        currentAmmo--;
        onAmmoChanged?.Invoke(currentAmmo);
    }

    public void ResetAmmo()
    {
        currentAmmo = maxAmmo;
        onAmmoChanged?.Invoke(currentAmmo);
    }
}
