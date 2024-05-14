using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistenceHandler : MonoBehaviour
{
    private GameData _gameData;
    private FileDataHandler _fileDataHandler;
    public string CurrentProfileID = "Player";

    private void Awake()
    {
        _fileDataHandler = new FileDataHandler(Application.persistentDataPath, CurrentProfileID);

    }

    public void Start()
    {

/*        if (GlobalPersistanceHandler.Instance.gameLoadMode == GameLoadMode.NewGame)
        {
            NewGame();
            return;
        }*/

        LoadGame();
    }

    public void NewGame()
    {
        _gameData = new GameData();
    }

    public void LoadGame()
    {
        _gameData = _fileDataHandler.Load(CurrentProfileID);

        if (_gameData == null)
        {
            Debug.Log("No data was found. A New Game needs to be started before data can be loaded. profile id");
            NewGame();
            return;
        }

        foreach (IDataPersistence dataPersistenceObject in FindAllDataPersistenceObjects())
        {
            dataPersistenceObject.LoadData(_gameData);
        }
    }

    public void SaveGame()
    {
        if (_gameData == null)
        {
            Debug.Log("No data was found. A New Game needs to be started before data can be saved");
            return;
        }

        foreach (IDataPersistence dataPersistenceObject in FindAllDataPersistenceObjects())
        {
            dataPersistenceObject.SaveData(_gameData);
        }

        _fileDataHandler.Save(_gameData, CurrentProfileID);

    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistencesObjects);
    }

    public bool HasGameData()
    {
        return _gameData != null;
    }


    public Dictionary<string, GameData> GetAllprofilesGameData()
    {
        return _fileDataHandler.LoadAllProfiles();
    }
}
