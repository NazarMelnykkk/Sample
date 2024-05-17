
[System.Serializable]
public class GameData
{
    public SoundsData SoundsData;
    public CoinsData CoinsData;
    public WheelFortuneSettingsData WheelFortuneSettingsData;

    public GameData()
    {
        SoundsData = new SoundsData();
        CoinsData = new CoinsData();
        WheelFortuneSettingsData = new WheelFortuneSettingsData();
    }
}