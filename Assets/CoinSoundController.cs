using UnityEngine;

public class CoinSoundController : MonoBehaviour
{
    [SerializeField] private SoundConfig _sound;
    [SerializeField] private ScoreViewController _scoreViewController;

    private void OnEnable()
    {
        _scoreViewController.OnScoreChangeEvent += PlaySound;
    }

    private void OnDisable()
    {
        _scoreViewController.OnScoreChangeEvent -= PlaySound;
    }

    private void PlaySound()
    {
        Debug.Log("SOUND");
        AudioHandler.Instance.PlaySound(_sound);
    }
}
