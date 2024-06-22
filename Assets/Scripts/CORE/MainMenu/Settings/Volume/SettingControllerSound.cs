public class SettingControllerSound : SettingControllerBase
{
    public void ChangeVolume(SoundType soundType, float value)
    {
        switch (soundType)
        {
            case SoundType.Master:
                SetVolume(soundType, value);
                break;
            case SoundType.UI:
                SetVolume(soundType, value);
                break;
            case SoundType.Music:
                SetVolume(soundType, value);
                break;
            case SoundType.Ambient:
                SetVolume(soundType, value);
                break;
            case SoundType.SFX:
                SetVolume(soundType, value);
                break;
        }
    }

    private void SetVolume(SoundType soundType, float value) 
    {
        SystemLinkHolder.Instance.AudioHandler.SetVolumeByType(soundType, value);
        
    }

    public float GetVolume(SoundType soundType)
    {
        return SystemLinkHolder.Instance.AudioHandler.GetVolumeByType(soundType);
    }
}
