using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string SoundName;
    public SoundType Type;
    public AudioClip AudioClip;
    [Range(-3, 3)] public float MinPitch = 0.9f;
    [Range(-3, 3)] public float MaxPitch = 1.1f;
}
