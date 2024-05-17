using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WheleOfFortune
{
    public class WheelOfFortuneSoundController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private WheelOfFortuneReferences _wheelOfFortuneReferences;

        [SerializeField] private Transform _wheelCircle;

        [Header("Sounds")]
        [SerializeField] private List<SoundConfig> _tickSounds;

        [Header("Coroutine")]
        private Coroutine _soundCoroutine;

        private void OnEnable()
        {
            _wheelOfFortuneReferences.WheelOfFortuneController.OnSpinStart(() =>
            {
                _soundCoroutine = StartCoroutine(SoundCoroutine());
            });

            _wheelOfFortuneReferences.WheelOfFortuneController.OnSpinEnd(WheelPiece =>
            {
                if (_soundCoroutine != null)
                {
                    StopCoroutine(_soundCoroutine);
                }
            });
        }

        private IEnumerator SoundCoroutine()
        {
            float pieceAngleHalf = _wheelOfFortuneReferences.PieceGenerator.GetPieceAngle();
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


}
