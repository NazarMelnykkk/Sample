using System;
using UnityEngine;
using static CoinsData;

public class CoinHandler : MonoBehaviour, IDataPersistence
{
    public static CoinHandler Instance;

    [Header("Actions")]
    public Action<int> OnValueChangeEvent;

    [Header("Values")]
    public int Coins;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        Coins += amount;
        OnValueChangeEvent?.Invoke(Coins);
    }

    public void RemoveCoins(int amount)
    {
        Coins -= amount;
        OnValueChangeEvent?.Invoke(Coins);
    }

    public int GetCoins(int amount)
    {
        if (Coins == 0)
        {
            return 0;
        }

        if (Coins < amount)
        {
            return 0;
        }

        Coins = Coins - amount;
        OnValueChangeEvent?.Invoke(Coins);
        return amount;
    }

    public int ChechAmount(int amount)
    {
        if (Coins == 0)
        {
            return 0;
        }

        if (Coins < amount)
        {
            return Coins;
        }

        return amount;
    }

    public void SaveData(GameData data)
    {
        if (data == null)
        {
            return;
        }

        CoinData pointData = new CoinData(Coins);

        data.CoinsData.CoinsValueData.Remove(name);
        data.CoinsData.CoinsValueData.Add(name,pointData);
    }

    public void LoadData(GameData data)
    {
        if (data == null && data.CoinsData == null)
        {
            return;
        }

        CoinData coinData;

        data.CoinsData.CoinsValueData.TryGetValue(name, out coinData);

        Coins = coinData.Coins;

        OnValueChangeEvent?.Invoke(Coins);
    }
}
