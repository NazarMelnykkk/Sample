using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VSynceControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _vSynceModeDropdown;

    void Start()
    {
        _vSynceModeDropdown.onValueChanged.AddListener(SetVSynce);

        List<TMP_Dropdown.OptionData> VSyncenOptions = new List<TMP_Dropdown.OptionData>();
        VSyncenOptions.Add(new TMP_Dropdown.OptionData("Enable"));
        VSyncenOptions.Add(new TMP_Dropdown.OptionData("Disable"));

        _vSynceModeDropdown.options = VSyncenOptions;

        if (QualitySettings.vSyncCount == 0)
        {
            _vSynceModeDropdown.value = 0;
        }
        else
        {
            _vSynceModeDropdown.value = 1;
        }
    }

    private void SetVSynce(int selectedVSynceIndex)
    {
        if (selectedVSynceIndex == 0)
        {
            QualitySettings.vSyncCount = 0;
        }
        else
        {
            QualitySettings.vSyncCount = 1;
        }
    }

}
