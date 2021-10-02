using UnityEngine;
using UnityEngine.Events;

[System.Serializable] class OnValueChanged : UnityEvent<int> { }

public class IntegerKeeperHelper : MonoBehaviour
{
    [SerializeField] private SOIntegerKeeper integerKeeper;
    
    [SerializeField] private bool resetValueOnAwake;

    [SerializeField] private OnValueChanged onValueChanged;
    [SerializeField] private UnityEvent onMinValueMet;
    [SerializeField] private UnityEvent onMaxValueMet;
    [SerializeField] private UnityEvent onValueReset;

    

    private void Awake()
    {
        if(resetValueOnAwake)
        {
            integerKeeper.ResetValue();
        }
    }

    private void OnEnable()
    {
        integerKeeper.onValueChanged += HandleValueChanged;
        integerKeeper.onMinValueMet += HandleMinValueMet;
        integerKeeper.onMaxValueMet += HandleMaxValueMet;
        integerKeeper.onValueReset += HandleValueReset;
    }

    private void OnDisable()
    {
        integerKeeper.onValueChanged -= HandleValueChanged;
        integerKeeper.onMinValueMet -= HandleMinValueMet;
        integerKeeper.onMaxValueMet -= HandleMaxValueMet;
        integerKeeper.onValueReset -= HandleValueReset;
    }

    private void HandleValueChanged(int value)
    {
        onValueChanged?.Invoke(value);
    }

    private void HandleMinValueMet()
    {
        onMinValueMet?.Invoke();
    }

    private void HandleMaxValueMet()
    {
        onMaxValueMet?.Invoke();
    }

    private void HandleValueReset()
    {
        onValueReset?.Invoke();
    }




}
