using UnityEngine;

public class SoundSlider : SliderBase
{
    [SerializeField] private SoundType _soundType;
    [SerializeField] private SettingControllerSound _controller;

    private void Start()
    {
        _slider.value = _controller.GetVolume(_soundType);
    }

    protected override void SetValue(float volume)
    {
        _controller.ChangeVolume(_soundType , volume);
    }
}
