using UnityEngine;

public class SystemLinkHolder : MonoBehaviour
{
    public static SystemLinkHolder Instance;

    [Header("Links")]
    public AudioHandler AudioHandler;
    public InputController InputController;
    public SceneLoader SceneLoader;
    public CoinHandler CoinHandler;

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
}
