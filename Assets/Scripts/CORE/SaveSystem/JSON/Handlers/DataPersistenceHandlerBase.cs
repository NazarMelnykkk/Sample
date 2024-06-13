using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistenceHandlerBase : MonoBehaviour
{
    protected GameData _gameData;
    protected FileDataHandler _fileDataHandler;
    protected string CurrentProfileID = "Plague.json";

    protected virtual void Awake()
    {
        _fileDataHandler = new FileDataHandler(Application.persistentDataPath, CurrentProfileID);
    }

    protected virtual void Start()
    {
        LoadGame();
    }

    protected virtual void NewGame()
    {
        _gameData = new GameData();
    }

    public virtual void LoadGame()
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

    public virtual void SaveGame()
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

    protected virtual void OnApplicationQuit()
    {
        SaveGame();
    }

    protected virtual List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistencesObjects);
    }

    protected virtual bool HasGameData()
    {
        return _gameData != null;
    }


    protected virtual Dictionary<string, GameData> GetAllprofilesGameData()
    {
        return _fileDataHandler.LoadAllProfiles();
    }
}
