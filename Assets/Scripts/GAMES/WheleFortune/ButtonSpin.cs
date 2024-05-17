using UnityEngine;
using UnityEngine.UI;

namespace WheleOfFortune 
{
    public class ButtonSpin : ButtonClickedBase
    {
        [Header("Components")]
        [SerializeField] private WheelOfFortuneController _wheelOfFortuneController;
        [SerializeField] private Image _image;

        [SerializeField] private Color _true, _false;

        public override void Click()
        {
            base.Click();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _wheelOfFortuneController.OnSpinStart(() =>
            {
                Debug.Log("Spin started");
                ChangeButtonColor(false);
            });

            _wheelOfFortuneController.OnSpinEnd(WheelPiece =>
            {
                Debug.Log("Spin ended");
                ChangeButtonColor(true);
            });
        }

        public void ChangeButtonColor(bool canSpin)
        {
            if (canSpin == true)
            {
                _image.color = _true;
            }
            else
            {
                _image.color = _false;
            }
        }
    }
}

