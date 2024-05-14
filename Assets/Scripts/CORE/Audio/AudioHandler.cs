using System;
using Unity.VisualScripting;
using UnityEngine;
using static SoundsData;
using static UnityEditor.Progress;

public class AudioHandler : MonoBehaviour, IDataPersistence
{
    public static AudioHandler Instance;

    [SerializeField] private SoundConfig[] _ui;
    [SerializeField] private SoundConfig[] _musics;
    [SerializeField] private SoundConfig[] _SFX;
    [SerializeField] private SoundConfig[] _ambients;

    [SerializeField] private AudioSource _uiAudioSource;
    [SerializeField] private AudioSource _musicAudioSource;
    [SerializeField] private AudioSource _SFXAudioSource;
    [SerializeField] private AudioSource _ambientAudioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(SoundType type, string soundID)
    {
        Sound currentSound = GetSoundByType(type, soundID);
        if (currentSound == null)
        {
            Debug.Log($"Sound {soundID} of type {type} not found");
            return;
        }

        AudioSource audioSource = GetAudioSourceByType(type);
        if (audioSource != null)
        {
            SetRandomPithcValue(audioSource, currentSound);
            audioSource.PlayOneShot(currentSound.AudioClip);
        }
    }

    public void PlaySound(SoundConfig config)
    {
        Sound currentSound = config.Sound;

        if (currentSound == null)
        {
            Debug.Log($"Config {config.name} not found");
            return;
        }

        AudioSource audioSource = GetAudioSourceByType(currentSound.Type);
        if (audioSource != null)
        {
            SetRandomPithcValue(audioSource, currentSound);
            audioSource.PlayOneShot(currentSound.AudioClip);
        }
    }

    public void ToggleSound(SoundType type)
    {
        if (type == SoundType.Master)
        {       
            return;
        }

        AudioSource audioSource = GetAudioSourceByType(type);

        if (audioSource != null)
        {
            audioSource.mute = !audioSource.mute;
        }
    }

    public void SetVolume(SoundType type, float volume)
    {
        if (type == SoundType.Master)
        {
            AudioListener.volume = volume;
            return;
        }

        AudioSource audioSource = GetAudioSourceByType(type);
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }

    public float GetVolumeByType(SoundType type)
    {
        switch (type)
        {
            case SoundType.Master:
                return AudioListener.volume;
            case SoundType.UI:
                return _uiAudioSource.volume;
            case SoundType.Music:
                return _musicAudioSource.volume;
            case SoundType.SFX:
                return _SFXAudioSource.volume;
            case SoundType.Ambient:
                return _ambientAudioSource.volume;
            default:
                Debug.LogError($"Unknown sound type {type}");
                return 0f;
        }
    }

    private void SetRandomPithcValue(AudioSource audioSource, Sound sound)
    {
        audioSource.pitch = UnityEngine.Random.Range(sound.MinPitch, sound.MaxPitch);
    }

    private Sound GetSoundByType(SoundType type, string soundName)
    {
        SoundConfig[] soundsArray = GetSoundsArrayByType(type);
        if (soundsArray == null)
        {
            Debug.Log($"Sounds of type {type} not found");
            return null;
        }

        SoundConfig foundSoundConfig = Array.Find(soundsArray, currentSound => currentSound.Sound.Name == soundName);
        if (foundSoundConfig == null)
        {
            Debug.Log($"Sound {soundName} of type {type} not found");
            return null;
        }

        return foundSoundConfig.Sound;
    }

    private SoundConfig[] GetSoundsArrayByType(SoundType type)
    {
        switch (type)
        {
            case SoundType.UI:
                return _ui;
            case SoundType.Music:
                return _musics;
            case SoundType.Ambient:
                return _ambients;
            case SoundType.SFX:
                return _SFX;
            default:
                Debug.Log($"Unknown sound type {type}");
                return null;
        }
    }

    private AudioSource GetAudioSourceByType(SoundType type)
    {
        switch (type)
        {
            case SoundType.UI:
                return _uiAudioSource;
            case SoundType.Music:
                return _musicAudioSource;
            case SoundType.Ambient:
                return _ambientAudioSource;
            case SoundType.SFX:
                return _SFXAudioSource;
            default:
                Debug.Log($"Unknown sound type {type}");
                return null;
        }
    }

    public void SaveData(GameData data)
    {
        if (data != null)
        {
            SoundData soundData;

            foreach (SoundType type in Enum.GetValues(typeof(SoundType)))
            {
                string id = type.ToString(); ;

                if (data.SoundsData.SoundVolumeData.ContainsKey(id) == true)
                {
                    data.SoundsData.SoundVolumeData.Remove(id);
                }

                if (type == SoundType.Master)
                {
                    soundData = new SoundData(AudioListener.volume);
                }
                else
                {
                    soundData = new SoundData(GetAudioSourceByType(type).volume);
                }

                data.SoundsData.SoundVolumeData.Add(id, soundData);
            }
        }
    }
    public void LoadData(GameData data)
    {
        if (data != null && data.SoundsData != null)
        {
            SoundData soundData;
            foreach (SoundType type in Enum.GetValues(typeof(SoundType)))
            {
                string id = type.ToString(); 

                data.SoundsData.SoundVolumeData.TryGetValue(id, out soundData);

                if (type == SoundType.Master)
                {
                    AudioListener.volume = soundData.Volume;
                }
                else
                {
                    AudioSource audioSource = GetAudioSourceByType(type);
                    audioSource.volume = soundData.Volume;
                }

            }
        }
    }
}
