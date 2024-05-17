[System.Serializable]
public class PointsData
{
    public SerializableDictionary<string, PointData> PointsValueData;

    public PointsData()
    {
        PointsValueData = new SerializableDictionary<string, PointData>();
    }

    [System.Serializable]
    public class PointData
    {
        public int Points;

        public PointData(int points)
        {
            Points = points;
        }
    }
}
