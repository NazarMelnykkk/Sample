using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.VFX;

public class ObjectPersistenceHandler : DataPersistenceHandlerBase
{
     public List<IDataPersistence> _saveObjects; 

    protected override void LoadGame()
    {
        _gameData = _fileDataHandler.Load(CurrentProfileID);

        if (_gameData == null)
        {
            Debug.Log("No data was found. A New Game needs to be started before data can be loaded. profile id");
            NewGame();
            return;
        }

        foreach (IDataPersistence dataPersistenceObject in _saveObjects)
        {
            dataPersistenceObject.LoadData(_gameData);
        }
    }

    protected override void SaveGame()
    {
        if (_gameData == null)
        {
            Debug.Log("No data was found. A New Game needs to be started before data can be saved");
            return;
        }

        foreach (IDataPersistence dataPersistenceObject in _saveObjects)
        {
            dataPersistenceObject.SaveData(_gameData);
        }

        _fileDataHandler.Save(_gameData, CurrentProfileID);

    }
}
