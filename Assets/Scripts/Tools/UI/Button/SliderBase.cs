using UnityEngine;
using UnityEngine.UI;

public class SliderBase : MonoBehaviour
{
    [SerializeField] protected Slider _slider;

    protected virtual void Awake()
    {
        _slider.onValueChanged.AddListener(SetValue);
    }

    protected virtual void SetValue(float currnetValue)
    {

    }
}
