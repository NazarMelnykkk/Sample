using UnityEngine;
using UnityEngine.UI;

public class UiEffectVolumeControl : MonoBehaviour
{
    [SerializeField] private Slider _uiEffectVolumeSlider;

    [SerializeField] private Button _saveButton;

    private void Start()
    {
        _saveButton.onClick.AddListener(SaveSoundEffectVolume);
        _uiEffectVolumeSlider.onValueChanged.AddListener(SetSoundEffectVolume);
    }

    private void SetSoundEffectVolume(float currnetValue)
    {

    }

    private void SaveSoundEffectVolume()
    {

    }
}
