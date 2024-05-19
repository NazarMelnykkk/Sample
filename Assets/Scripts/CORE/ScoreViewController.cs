using System;
using TMPro;
using UnityEngine;

public class ScoreViewController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;

    private int _currentScore;

    public Action OnScoreChangeEvent;

    private void ChangeValue(int value)
    {
        _currentScore += value;
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
