using UnityEngine;

namespace WheleOfFortune
{
    public class SliderChangerPower : SliderBase
    {
        [SerializeField] private WheelOfFortuneSettingController _wheelOfFortuneSettingController;
        [SerializeField] private PowerType _powerType;

        private const float _maxRotate = 3000f;
        private const float _minRotate = 500f;

        private const float _maxStopping = 1000f;
        private const float _minStopping = 500f;

        private const float _maxRandom = 400f;
        private const float _minRandom = 50f;

        private void OnEnable()
        {
            switch (_powerType)
            {
                case PowerType.Rotate:
                    _slider.value = Mathf.InverseLerp(_minRotate, _maxRotate, _wheelOfFortuneSettingController.GetPower(PowerType.Rotate));
                    break;

                case PowerType.Stopping:
                    _slider.value = Mathf.InverseLerp(_minStopping, _maxStopping, _wheelOfFortuneSettingController.GetPower(PowerType.Stopping));
                    break;

                case PowerType.Random:
                    _slider.value = Mathf.InverseLerp(_minRandom, _maxRandom, _wheelOfFortuneSettingController.GetPower(PowerType.Random));
                    break;

                default:
                    break;
            }
        }

        protected override void SetValue(float currentValue)
        {
            switch (_powerType)
            {
                case PowerType.Rotate:
                    _wheelOfFortuneSettingController.ChangePower(_powerType, Mathf.Lerp(_minRotate, _maxRotate, currentValue));
                    break;

                case PowerType.Stopping:
                    _wheelOfFortuneSettingController.ChangePower(_powerType, Mathf.Lerp(_minStopping, _maxStopping, currentValue));
                    break;

                case PowerType.Random:
                    _wheelOfFortuneSettingController.ChangePower(_powerType, Mathf.Lerp(_minRandom, _maxRandom, currentValue));
                    break;

                default:
                    break;
            }
        }
    }
}

