
[System.Serializable]
public class SoundsData
{
    public SerializableDictionary<string,SoundData> SoundVolumeData;

    public SoundsData()
    {
        SoundVolumeData = new SerializableDictionary<string,SoundData>();
    }

    [System.Serializable]
    public class SoundData
    {
        public float Volume;

        public SoundData(float volume)
        {
            Volume = volume;
        }
    }
}
