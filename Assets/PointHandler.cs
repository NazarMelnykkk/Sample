using System;
using UnityEngine;

public class PointHandler : MonoBehaviour
{
    [Header("Actions")]
    public Action OnValueChangeEvent;

    [Header("Values")]
    public int Points;

    private void Start()
    {
        LoadData();
    }

    public void LoadData()
    {
        Points = PlayerPrefs.GetInt("Points", 0);
        OnValueChangeEvent?.Invoke();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Points", Points);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    public void AddPoints(int amount)
    {
        Points += amount;
        SaveData();
        OnValueChangeEvent?.Invoke();
    }

    // Method to set points and trigger event
    public void SetPoints(int newPoints)
    {
        Points = newPoints;
        SaveData();
        OnValueChangeEvent?.Invoke();
    }
}
