using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPersistenceHandler : DataPersistenceHandlerBase
{
    [Tooltip("Object with IDataPersistence")][SerializeField, GameObjectOfType(typeof(IDataPersistence))] List<GameObject> _saveObjects;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void LoadGame()
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

    public override void SaveGame()
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

    protected override List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        List<IDataPersistence> dataPersistencesObjects = new List<IDataPersistence>();

        foreach (Object obj in _saveObjects)
        {
            IDataPersistence interfave = obj.GetComponent<IDataPersistence>();
            dataPersistencesObjects.Add(interfave);
        }

        return dataPersistencesObjects;
    }
}
