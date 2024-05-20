using System;
using TMPro;
using UnityEngine;

public class ScoreViewController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;

    [SerializeField] private int _currentScore;

    public Action OnScoreChangeEvent;

    private void Start()
    {
        DrawView();
    }

    public void ChangeValue(int value)
    {
        _currentScore += value;
        DrawView();
        OnScoreChangeEvent?.Invoke();

        CoinHandler.Instance.AddCoins(value);
    }

    private void Restart()
    {
        _currentScore = 0;
    }

    private void DrawView()
    {
        _score.text = $"Score: {_currentScore}";
    }
}
