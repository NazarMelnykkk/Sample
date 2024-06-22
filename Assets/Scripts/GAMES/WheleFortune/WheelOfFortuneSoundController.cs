using System;
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
            _wheelOfFortuneReferences.WheelOfFortuneController.OnSpinStartEvent += StartPlay;
            _wheelOfFortuneReferences.WheelOfFortuneController.OnSpinEndEvent += StopPlay;         
        }

        private void OnDisable()
        {
            _wheelOfFortuneReferences.WheelOfFortuneController.OnSpinStartEvent -= StartPlay;
            _wheelOfFortuneReferences.WheelOfFortuneController.OnSpinEndEvent -= StopPlay;
        }

        private void StartPlay()
        {
            _soundCoroutine = StartCoroutine(SoundCoroutine());
        }

        private void StopPlay()
        {
            StopCoroutine(_soundCoroutine);
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
            int randomIndex = UnityEngine.Random.Range(0, _tickSounds.Count);
            SystemLinkHolder.Instance.AudioHandler.PlaySound(_tickSounds[randomIndex]);
        }
    }


}
