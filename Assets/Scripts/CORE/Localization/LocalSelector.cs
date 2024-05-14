using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Localization.Settings;
public class LocalSelector : MonoBehaviour
{
    private bool _active = false;

    private void Start()
    {
        int ID = PlayerPrefs.GetInt("LocaleKey", 0);
        ChangeLocale(ID);
    }

    public void ChangeLocale(int localeID)
    {
        if (_active == true)
        {
            return;
        }
        
        StartCoroutine(SetLocale(localeID));
    }

   IEnumerator SetLocale(int localeID)
   {
        _active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        _active = false;
    }
}
