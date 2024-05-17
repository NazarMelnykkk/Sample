[System.Serializable]
public class CoinsData
{
    public SerializableDictionary<string, CoinData> CoinsValueData;

    public CoinsData()
    {
        CoinsValueData = new SerializableDictionary<string, CoinData>();
    }

    [System.Serializable]
    public class CoinData
    {
        public int Coins;

        public CoinData(int points)
        {
            Coins = points;
        }
    }
}
