using System;
using TMPro;
using UnityEngine;


public class InputFieldBase : MonoBehaviour
{
    protected TMP_InputField _inputField;
    public event Action<string> OnValueChangeEvent;

    protected virtual void Awake()
    {
        _inputField = GetComponent<TMP_InputField>();
    }

    protected virtual void OnEnable()
    {
        _inputField.onValueChanged.AddListener(ValueChange);
    }

    protected virtual void OnDisable()
    {
        _inputField.onValueChanged.RemoveListener(ValueChange);
    }

    public virtual void ValueChange(string value)
    {
        OnValueChangeEvent?.Invoke(value);
    }

}
