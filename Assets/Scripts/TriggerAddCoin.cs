using UnityEngine;

public class TriggerAddCoin : MonoBehaviour
{
    [SerializeField] private ScoreViewController _scoreViewController;
    [SerializeField] private int _coinToAdd = 1;

    [SerializeField] private string _triggerLayerName = "Coin";

    private void Start()
    {
        _scoreViewController = FindObjectOfType<ScoreViewController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(_triggerLayerName))
        {
            Debug.Log("Coin collected");
            AddCoin();
        }
    }

    private void AddCoin()
    {
        _scoreViewController.ChangeValue(_coinToAdd);
    }
}
