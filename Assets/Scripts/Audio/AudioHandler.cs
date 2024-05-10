using System;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{

    [SerializeField] private Sound[] _ui;
    [SerializeField] private Sound[] _musics;
    [SerializeField] private Sound[] _SFX;
    [SerializeField] private Sound[] _ambients;

    [SerializeField] private AudioSource _uiAudioSource;
    [SerializeField] private AudioSource _musicAudioSource;
    [SerializeField] private AudioSource _SFXAudioSource;
    [SerializeField] private AudioSource _ambientAudioSource;

    public void PlaySound(SoundType type, string soundName)
    {
        Sound currentSound = GetSoundByType(type, soundName);
        if (currentSound == null)
        {
            Debug.Log($"Sound {soundName} of type {type} not found");
            return;
        }

        AudioSource audioSource = GetAudioSourceByType(type);
        if (audioSource != null)
        {
            SetRandomPithcValue(audioSource, currentSound);
            audioSource.PlayOneShot(currentSound.AudioClip);
        }
    }

    public void PlaySound(Sound currentSound)
    {

        if (currentSound == null)
        {
            Debug.Log($"Sound {currentSound.SoundName} of type {currentSound.Type} not found");
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
        Sound[] soundsArray = GetSoundsArrayByType(type);
        if (soundsArray == null)
        {
            Debug.Log($"Sounds of type {type} not found");
            return null;
        }

        return Array.Find(soundsArray, currentSound => currentSound.SoundName == soundName);
    }

    private Sound[] GetSoundsArrayByType(SoundType type)
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
