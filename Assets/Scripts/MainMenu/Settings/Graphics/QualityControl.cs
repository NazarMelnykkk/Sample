using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QualityControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _qualityLevelDropdown;

    private List<string> _qualityLevels;

    //[SerializeField] private UniversalRenderPipelineAsset _universalRenderPipelineAsset;

    void Start()
    {
        _qualityLevelDropdown.onValueChanged.AddListener(SetQuality);

        string[] qualityNames = QualitySettings.names;
        _qualityLevels = new List<string>(qualityNames);


        _qualityLevelDropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        foreach (string qualityLevel in _qualityLevels)
        {
            options.Add(new TMP_Dropdown.OptionData(qualityLevel));
        }

        _qualityLevelDropdown.AddOptions(options);

        // Устанавливаем начальное значение dropdown
        _qualityLevelDropdown.value = QualitySettings.GetQualityLevel();
    }

    private void SetQuality(int selectedQualityIndex)
    {
        QualitySettings.SetQualityLevel(selectedQualityIndex);

       /* if (_universalRenderPipelineAsset != null)
        {
            GraphicsSettings.renderPipelineAsset = _universalRenderPipelineAsset;
        }*/
    }
}

