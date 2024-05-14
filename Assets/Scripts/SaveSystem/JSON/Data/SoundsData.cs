using System.Collections.Generic;

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
        public SoundType Type;
        public float Volume;

        public SoundData(SoundType type , float volume)
        {
            Type = type;
            Volume = volume;
        }
    }
}
