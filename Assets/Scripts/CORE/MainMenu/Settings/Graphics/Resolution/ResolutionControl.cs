using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEditor.Rendering;

public class ResolutionControl : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown _resolutionDropdown;

    private Resolution[] _resolution;
    private List<Resolution> _filterResolutions;

    private float _currentRefreshRate;
    private int _currentResolutionIndex = 0;

    private void Start()
    {
        _resolutionDropdown.onValueChanged.AddListener(SetResolution);


        _resolution = Screen.resolutions;
        _filterResolutions = new List<Resolution>();

        _resolutionDropdown.ClearOptions();
#pragma warning disable CS0618 // Тип или член устарел
        _currentRefreshRate = Screen.currentResolution.refreshRate;
#pragma warning restore CS0618 // Тип или член устарел

        for (int i = 0; i < _resolution.Length; i++)
        {
#pragma warning disable CS0618 // Тип или член устарел
            if (_resolution[i].refreshRate == _currentRefreshRate)
            {
                _filterResolutions.Add(_resolution[i]);
            }
#pragma warning restore CS0618 // Тип или член устарел
        }

        List<string> options = new List<string>();

        for (int i = 0; i < _filterResolutions.Count; i++)
        {
#pragma warning disable CS0618 // Тип или член устарел
            string resolutionOption = _filterResolutions[i].width + "x" + _filterResolutions[i].height + " " + _filterResolutions[i].refreshRate + "Hz";
#pragma warning restore CS0618 // Тип или член устарел
            options.Add(resolutionOption);

            if (_filterResolutions[i].width == Screen.width && _filterResolutions[i].height == Screen.height)
            {
                _currentResolutionIndex = i;
            }
        }


        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.value = _currentResolutionIndex;
        _resolutionDropdown.RefreshShownValue();
    }

    private void SetResolution(int selectedResolutionIndex)
    {
        Resolution resolution = _filterResolutions[selectedResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
}
