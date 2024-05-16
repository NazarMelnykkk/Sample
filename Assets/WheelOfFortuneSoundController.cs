using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelOfFortuneSoundController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private WheelOfFortuneController _wheelOfFortuneController;
    [SerializeField] private PieceGenerator _pieceGenerator;

    [SerializeField] private Transform _wheelCircle;

    [Header("Sounds")]
    [SerializeField] private List<SoundConfig> _tickSounds;

    [Header("Coroutine")]
    private  Coroutine _soundCoroutine;

    private void OnEnable()
    {
        _wheelOfFortuneController.OnSpinStart(() =>
        {
            _soundCoroutine = StartCoroutine(SoundCoroutine());
        });

        _wheelOfFortuneController.OnSpinEnd(WheelPiece =>
        {
           if (_soundCoroutine != null)
           {
                StopCoroutine(_soundCoroutine);
           }
        });
    }

    private IEnumerator SoundCoroutine()
    {
        float pieceAngleHalf = _pieceGenerator.GetPieceAngle() / 2f;
        float previousAngle = _wheelCircle.rotation.eulerAngles.z;

        while (true)
        {
            yield return null;

            float currentAngle = _wheelCircle.rotation.eulerAngles.z;
            float angleDifference = Mathf.Abs(Mathf.DeltaAngle(previousAngle, currentAngle));

            if (angleDifference >= pieceAngleHalf)
            {
                PlayTickSound();
                previousAngle = currentAngle;
            }
        }
    }

    public void PlayTickSound()
    {
        int randomIndex = Random.Range(0, _tickSounds.Count);
        AudioHandler.Instance.PlaySound(_tickSounds[randomIndex]);
    }
}
