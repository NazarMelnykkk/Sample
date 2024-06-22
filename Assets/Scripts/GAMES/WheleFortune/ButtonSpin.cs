using UnityEngine;
using UnityEngine.UI;

namespace WheleOfFortune 
{
    public class ButtonSpin : ButtonCustomBase
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

            _wheelOfFortuneController.OnSpinStartEvent += Deactivate;
            _wheelOfFortuneController.OnSpinEndEvent += Activate;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _wheelOfFortuneController.OnSpinStartEvent -= Deactivate;
            _wheelOfFortuneController.OnSpinEndEvent -= Activate;
        }

        public void Activate()
        {
            _image.color = _true;
        }

        public void Deactivate()
        {
            _image.color = _false;
        }
    }
}

