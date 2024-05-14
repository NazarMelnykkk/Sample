using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _displayDropdown;

    private List<Display> _displays;
    private int _currentDisplayIndex = 0;

    private void Start()
    {
        _displayDropdown.onValueChanged.AddListener(SetDisplay);

        _displays = new List<Display>();
        _displayDropdown.ClearOptions();

        foreach (Display display in Display.displays)
        {
            _displays.Add(display);
        }

        List<string> options = new List<string>();
        for (int i = 0; i < _displays.Count; i++)
        {
            options.Add($"Display {i + 1}");
        }

        _displayDropdown.AddOptions(options);

        _displayDropdown.value = _currentDisplayIndex;
        _displayDropdown.RefreshShownValue();
    }

    private void SetDisplay(int selectedDisplayIndex )
    {
        if (selectedDisplayIndex >= 0 && selectedDisplayIndex < _displays.Count)
        {
            Display.displays[1].Activate(0, 0, new RefreshRate() { numerator = 60, denominator = 1 });
        }
    }
}
