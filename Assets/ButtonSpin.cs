using EasyUI.PickerWheelUI;
using TMPro;
using UnityEngine;

public class ButtonSpin : ButtonClickedBase
{
    [Header("Components")]
    [SerializeField] private PickerWheel _wheel;
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Color _true, _false;

    public override void Click()
    {
        base.Click();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        _wheel.OnSpinStart(() =>
        {
            ChangeButtonColor(false);
        });
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        _wheel.OnSpinEnd(WheelPiece =>
        {
            ChangeButtonColor(true);
        });
    }

    public void ChangeButtonColor(bool canSpin)
    {
        if(canSpin == true)
        {
            _text.color = _true;
        }
        else
        {
            _text.color = _false;
        }
    }
}
