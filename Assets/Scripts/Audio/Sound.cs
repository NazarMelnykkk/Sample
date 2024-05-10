using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string Name;
    public SoundType Type;
    public AudioClip AudioClip;
    [Range(-3, 3)] public float MinPitch = 1f;
    [Range(-3, 3)] public float MaxPitch = 1f;
}
