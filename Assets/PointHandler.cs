using System;
using UnityEngine;
using static PointsData;
using static SoundsData;

public class PointHandler : MonoBehaviour, IDataPersistence
{
    [Header("Actions")]
    public Action OnValueChangeEvent;

    [Header("Values")]
    public int Points;

    public void AddPoints(int amount)
    {
        Points += amount;
        OnValueChangeEvent?.Invoke();
    }

    public int GetPoints(int amount)
    {
        if (Points == 0)
        {
            return 0;
        }

        if (Points < amount)
        {
            return 0;
        }

        Points = Points - amount;
        OnValueChangeEvent?.Invoke();
        return amount;
    }

    public void SaveData(GameData data)
    {
        if (data == null)
        {
            return;
        }

        PointData pointData = new PointData(Points);

        data.PointsData.PointsValueData.Remove(name);
        data.PointsData.PointsValueData.Add(name,pointData);
    }

    public void LoadData(GameData data)
    {
        if (data == null && data.PointsData == null)
        {
            return;
        }

        PointData pointData;

        data.PointsData.PointsValueData.TryGetValue(name, out pointData);

        Points = pointData.Points;

        OnValueChangeEvent?.Invoke();
    }
}
