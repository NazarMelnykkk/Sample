
[System.Serializable]
public class GameData
{
    public SoundsData SoundsData;
    public PointsData PointsData;
    public WheelFortuneSettingsData WheelFortuneSettingsData;

    public GameData()
    {
        SoundsData = new SoundsData();
        PointsData = new PointsData();
        WheelFortuneSettingsData = new WheelFortuneSettingsData();
    }
}