
[System.Serializable]
public class GameData
{
    public SoundsData SoundsData;
    public WheelFortuneSettingsData WheelFortuneSettingsData;

    public GameData()
    {
        WheelFortuneSettingsData = new WheelFortuneSettingsData();
    }
}