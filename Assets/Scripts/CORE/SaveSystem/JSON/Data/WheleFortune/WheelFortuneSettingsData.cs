[System.Serializable]
public class WheelFortuneSettingsData 
{

    public SerializableDictionary<string, WheelFortuneSettingData> WheelFortuneData;

    public WheelFortuneSettingsData()
    {
        WheelFortuneData = new SerializableDictionary<string, WheelFortuneSettingData>();
    }

    [System.Serializable]
    public class WheelFortuneSettingData
    {
        public float Size;
        public float RotatePower;
        public float StoppingPower;
        public float RandomizationCoefficient;
  
        public WheelFortuneSettingData(float size, float rotatePower, float stoppingPower, float randomizationCoefficient)
        {
            Size = size;
            RotatePower = rotatePower;
            StoppingPower = stoppingPower;
            RandomizationCoefficient = randomizationCoefficient;
        }
    }
}
