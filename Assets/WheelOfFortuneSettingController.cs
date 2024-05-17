using System;
using UnityEngine;
using static WheelFortuneSettingsData;

namespace WheleOfFortune 
{
    public class WheelOfFortuneSettingController : MonoBehaviour, IDataPersistence
    {
        [Header("Components")]
        [SerializeField] private WheelOfFortuneReferences _wheelOfFortuneReferences;

        [Header("Configuration")]
        [Range(0.2f, 2f)] public float WheelSize = 1f;

        public float RotatePower = 1000f;
        public float StoppingPower = 600f;
        public float RandomizationCoefficient = 100f;

        public float CurrentBet = 10;

        [Header("Pieces")]
        public WheelPiece[] WheelPieces;

        public void SaveData(GameData data)
        {
            if (data != null)
            {
                WheelFortuneSettingData wheleData;

                wheleData = new WheelFortuneSettingData(WheelSize, RotatePower, StoppingPower, RandomizationCoefficient, CurrentBet);
                data.WheelFortuneSettingsData.WheelFortuneData.Add(name, wheleData);
            }
        }

        public void LoadData(GameData data)
        {
            if (data != null && data.WheelFortuneSettingsData != null)
            {
                WheelFortuneSettingData wheleData;

                data.WheelFortuneSettingsData.WheelFortuneData.TryGetValue(name, out wheleData);

                WheelSize = wheleData.Size;

                RotatePower = wheleData.RotatePower;
                StoppingPower = wheleData.StoppingPower;
                RandomizationCoefficient = wheleData.RandomizationCoefficient;

                CurrentBet = wheleData.CurrentBet;
            }

            _wheelOfFortuneReferences.PieceGenerator.Generate();
        }

        private void OnValidate()
        {
            _wheelOfFortuneReferences.PieceGenerator.ChangeSize();
        }
    }


}

