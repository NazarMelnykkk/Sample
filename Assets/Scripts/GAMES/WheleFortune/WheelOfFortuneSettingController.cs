using System;
using UnityEngine;
using static WheelFortuneSettingsData;

namespace WheleOfFortune
{
    public enum PowerType 
    {
        Rotate,
        Stopping,
        Random
    }

    public class WheelOfFortuneSettingController : MonoBehaviour, IDataPersistence
    {
        [Header("Components")]
        [SerializeField] private WheelOfFortuneReferences _wheelOfFortuneReferences;

        [Header("Configuration")]
        [Range(0.2f, 2f)] public float WheelSize = 1f;

        [Range(500f, 3000f)] public float RotatePower = 3000f;
        [Range(500f, 1000f)] public float StoppingPower = 1000f;
        [Range(50f, 400f)] public float RandomizationCoefficient = 400f;

        [Header("Pieces")]
        public WheelPiece[] WheelPieces;

        public void ChangePower(PowerType type , float value)
        {
            switch (type)
            {
                case PowerType.Rotate:
                    RotatePower = value;
                   break;

                case PowerType.Stopping:
                    StoppingPower = value;
                    break;

                case PowerType.Random:
                    RandomizationCoefficient = value;
                    break;
            }
        }

        public float GetPower(PowerType type)
        {
            switch (type)
            {
                case PowerType.Rotate:
                    return RotatePower;

                case PowerType.Stopping:
                    return StoppingPower;

                case PowerType.Random:
                    return RandomizationCoefficient;

                default: return 0.0f;
            }
        }

        public void ChangeSize(float Size)
        {
            WheelSize = Size;
            _wheelOfFortuneReferences.PieceGenerator.ChangeSize();
        }

        public void SaveData(GameData data)
        {
            if (data != null)
            {
                WheelFortuneSettingData wheleData;

                wheleData = new WheelFortuneSettingData(WheelSize, RotatePower, StoppingPower, RandomizationCoefficient);

                if (data.WheelFortuneSettingsData.WheelFortuneData.ContainsKey(name) == true)
                {
                    data.WheelFortuneSettingsData.WheelFortuneData.Remove(name);
                }

                data.WheelFortuneSettingsData.WheelFortuneData.Add(name, wheleData);

            }
        }

        public void LoadData(GameData data)
        {
            if (data != null && data.WheelFortuneSettingsData != null && data.WheelFortuneSettingsData.WheelFortuneData != null)
            {
                WheelFortuneSettingData wheleData;

                data.WheelFortuneSettingsData.WheelFortuneData.TryGetValue(name, out wheleData);
                if (wheleData != null)
                {
                    WheelSize = wheleData.Size;
                    RotatePower = wheleData.RotatePower;
                    StoppingPower = wheleData.StoppingPower;
                    RandomizationCoefficient = wheleData.RandomizationCoefficient;
                }
            }
        }

        private void OnValidate()
        {
            _wheelOfFortuneReferences.PieceGenerator.ChangeSize();
        }

    }
}

