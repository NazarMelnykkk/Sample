using UnityEngine;

public class Saver : MonoBehaviour
{
    [SerializeField] private ObjectPersistenceHandler _persistenceHandler;
    [SerializeField] private ButtonClickedBase _backToMenu;

    private void OnEnable()
    {
        _backToMenu.OnButtonClick += Save;
    }

    private void OnDisable()
    {
        _backToMenu.OnButtonClick -= Save;
    }

    private void Save()
    {
        if (_persistenceHandler == null)
        {
            _persistenceHandler = FindObjectOfType<ObjectPersistenceHandler>();
        }

        if (_persistenceHandler != null)
        {
            _persistenceHandler.SaveGame();
        }
        else
        {
            Debug.Log("Persistence Handler not found!!!");
        }
    }
}
