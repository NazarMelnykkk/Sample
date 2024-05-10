using System;
using UnityEngine;

public class AudioHandler : MonoBehaviour
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
        AudioSource audioSource = GetAudioSourceByType(type);

        if (audioSource != null)
        {
            audioSource.mute = !audioSource.mute;
        }
    }

    public void SetVolume(SoundType type, float volume)
    {
        AudioSource audioSource = GetAudioSourceByType(type);
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }

    public float GetVolume(SoundType type)
    {
        AudioSource audioSource = GetAudioSourceByType(type);

        if (audioSource != null)
        {
            return audioSource.volume;
        }

        return 0f;
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
}
