using UnityEngine;

[CreateAssetMenu(menuName = "Config/Sound")] 
public class SoundConfig : ScriptableObject
{
    public Sound Sound;


    private void OnValidate()
    {
        if (Sound.Name != "")
        {
            name = Sound.Name;
        }

        // ensure the id is always the name of the SO asset
#if UNITY_EDITOR

        name = Sound.Name;
        UnityEditor.EditorUtility.SetDirty(this);
#endif

    }
}
