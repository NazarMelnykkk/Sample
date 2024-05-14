using UnityEngine;

[CreateAssetMenu(menuName = "Config/Sound")] 
public class SoundConfig : ScriptableObject
{
    public string ID;

    public Sound Sound;


    private void OnValidate()
    {
        if (Sound.Name == "" && name != "")
        {
            Sound.Name = name;
        }

        // ensure the id is always the name of the SO asset
#if UNITY_EDITOR

        ID = name;
        UnityEditor.EditorUtility.SetDirty(this);
#endif

    }
}
