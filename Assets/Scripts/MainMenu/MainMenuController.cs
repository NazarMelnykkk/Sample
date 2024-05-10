using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private ButtonClickedBase _exitButton;

    [Header("Sound")]
    private string _soundID = "UIClick";
    private SoundType _soundType = SoundType.UI;

    private void OnEnable()
    {
        _exitButton.OnButtonClick += PlaySound;
    }

    private void OnDisable()
    {
        _exitButton.OnButtonClick -= PlaySound;
    }

    private void PlaySound()
    {
        AudioHandler.Instance.PlaySound(_soundType, _soundID);
    }
}
