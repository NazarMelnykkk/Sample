using UnityEngine;

namespace WheleOfFortune
{
    public class SliderSizeChanger : SliderBase
    {
        [SerializeField] private WheelOfFortuneSettingController _wheelOfFortuneSettingController;

        private const float minSize = 0.2f;
        private const float maxSize = 2.0f;

        private void Start()
        {
            _slider.value = Mathf.InverseLerp(minSize, maxSize, _wheelOfFortuneSettingController.WheelSize);
        }

        protected override void SetValue(float currentValue)
        {
            _wheelOfFortuneSettingController.ChangeSize(Mathf.Lerp(minSize, maxSize, currentValue));

        }
    }
} 

