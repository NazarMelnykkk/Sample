using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// basic component for a button
/// </summary>
[RequireComponent(typeof(Button))]
public class ButtonClickedBase : MonoBehaviour
{

    protected Button Button;
    public event Action OnButtonClick;

    protected virtual void Awake()
    {
        Button = GetComponent<Button>();
    }

    protected virtual void OnEnable()
    {
        Button.onClick.AddListener(Click);
    }

    protected virtual void OnDisable()
    {
        Button.onClick.RemoveListener(Click);
    }

    public virtual void Click()
    {
        OnButtonClick?.Invoke();
    }
}
