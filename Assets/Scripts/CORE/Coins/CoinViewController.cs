using TMPro;
using UnityEngine;

public class CoinViewController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;


    private void OnEnable()
    {
        CoinHandler.Instance.OnValueChangeEvent += DrawCoins;
    }

    protected void OnDisable()
    {
        CoinHandler.Instance.OnValueChangeEvent -= DrawCoins;
    }

    protected void Start()
    {
        _text.text = $"Coins: {CoinHandler.Instance.Coins}";
    }

    private void DrawCoins(int value)
    {
        _text.text = $"Coins: {value}";
    }
}
