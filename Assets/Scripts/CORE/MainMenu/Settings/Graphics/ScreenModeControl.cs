using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenModeControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _screenModeDropdown;

    private void Start()
    {
        _screenModeDropdown.onValueChanged.AddListener(SetScreenMode);

        List<TMP_Dropdown.OptionData> dropdownOptions = new List<TMP_Dropdown.OptionData>();
        dropdownOptions.Add(new TMP_Dropdown.OptionData("FullScreen"));
        dropdownOptions.Add(new TMP_Dropdown.OptionData("Maximized"));
        dropdownOptions.Add(new TMP_Dropdown.OptionData("Windowed"));

        _screenModeDropdown.options = dropdownOptions;
    }

    private void SetScreenMode(int screenModeIndex)
    {
        switch (screenModeIndex)
        {
            case 0:
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.FullScreenWindow);
                break;

            case 1:
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.MaximizedWindow);
                break;

            case 2:
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.Windowed);
                break;

            default:
                break;
        }
    }
}
