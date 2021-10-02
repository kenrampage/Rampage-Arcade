using UnityEngine;
using System;

[CreateAssetMenu(fileName = "IntegerKeeper_", menuName = "Rampage Arcade/SOIntegerKeeper")]
public class SOIntegerKeeper : ScriptableObject
{
    [SerializeField] private int defaultValue;
    [SerializeField] private int value;
    [SerializeField] private int maxValue = 99999;
    [SerializeField] private int minValue;

    public Action<int> onValueChanged;
    public Action onMaxValueMet;
    public Action onMinValueMet;
    public Action onValueReset;

    public void IncrementValue()
    {

        if (value < maxValue)
        {
            value++;
            onValueChanged?.Invoke(value);
        }


        CheckMinMaxValue();
    }

    public void DecrementValue()
    {
        if (value > minValue)
        {
            value--;
            onValueChanged?.Invoke(value);
        }

        CheckMinMaxValue();
    }

    public void SetValue(int i)
    {
        if (i != value)
        {
            value = i;
            onValueChanged?.Invoke(value);
        }

        CheckMinMaxValue();
    }

    public void ResetValue()
    {
        value = defaultValue;
        onValueReset?.Invoke();
    }

    public void CheckMinMaxValue()
    {
        if (value <= minValue)
        {
            onMinValueMet?.Invoke();
        }

        if (value >= maxValue)
        {
            onMaxValueMet?.Invoke();
        }

    }
}
