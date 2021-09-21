using UnityEngine;
using System;

[CreateAssetMenu(fileName = "FMODParameterData_", menuName = "Rampage Arcade/SO_FMODParameterData", order = 0)]
public class SO_FMODParameterData : ScriptableObject
{
    public event Action<float> onValueUpdated;
    private float floatValue;
    public float FloatValue
    {
        get
        {
            return floatValue;
        }
        set
        {
            floatValue = value;
            onValueUpdated?.Invoke(value);
        }
    }

}
