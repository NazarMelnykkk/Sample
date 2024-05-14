using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileDataHandler 
{
    private string _dataDirPath = "";

    private string _dataFileName = "";

    private readonly string backupExtension = ".bak";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        _dataDirPath = dataDirPath;
        _dataFileName = dataFileName;
    }

    public GameData Load(string profileID, bool allowRestoreFromBackup = true)
    {
        if (profileID == null)
        {
            return null;
        }

        string fullPath = Path.Combine(_dataDirPath, profileID, _dataFileName);
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";

                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception ex)
            {
                if (allowRestoreFromBackup == true)
                {
                    Debug.LogError("Failed to load data file. Attemting to roll back:" + ex);
                    bool rollbackSuccess = AttemptRollback(fullPath);

                    if (rollbackSuccess == true)
                    {
                        loadedData = Load(profileID, false);
                    }
                }
                else
                {
                    Debug.LogError("Erroe occured when trying to load file at path: " + fullPath + "and backup did not work" + ex);
                }
            }

        }
        return loadedData;
    }

    public void Save(GameData data, string profileID)
    {
        if (profileID == null)
        {
            return;
        }

        string fullPath = Path.Combine(_dataDirPath, profileID, _dataFileName);
        string backupFilePath = fullPath + backupExtension;

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine(dataToStore);
                }
            }

            GameData verifiedGameData = Load(profileID);

            if (verifiedGameData != null)
            {
                File.Copy(fullPath, backupFilePath, true);
            }
            else
            {
                throw new Exception("Save file could not be verified and backup could not be created");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error ocured when trying to save data to file:" + fullPath + "\n" + ex);
        }
    }

    public void Delete(string profileId)
    {
        if (profileId == null)
        {
            return;
        }

        string fullPath = Path.Combine(_dataDirPath, profileId, _dataFileName);

        try
        {

            if (File.Exists(fullPath))
            {
                Directory.Delete(Path.GetDirectoryName(fullPath), true);
            }
            else
            {
                Debug.LogWarning("Tried to delete profile data, but data was not found at path:" + fullPath);
            }

        }
        catch (Exception ex)
        {

            Debug.LogError("Failed to delete profile data for profileID" + profileId + "at path" + fullPath + "\n" + ex);
        }
    }

    public Dictionary<string, GameData> LoadAllProfiles()
    {
        Dictionary<string, GameData> profileDictionary = new Dictionary<string, GameData>();

        IEnumerable<DirectoryInfo> directoryInfos = new DirectoryInfo(_dataDirPath).EnumerateDirectories();

        foreach (DirectoryInfo directoryInfo in directoryInfos)
        {
            string profileID = directoryInfo.Name;

            string fullPath = Path.Combine(_dataDirPath, profileID, _dataFileName);

            if (File.Exists(fullPath) == false)
            {
                Debug.Log("Skipping directory when loading all profiles because it does not contain data:" + profileID);
                continue;
            }

            GameData profileData = Load(profileID);

            if (profileData != null)
            {
                profileDictionary.Add(profileID, profileData);
            }
            else
            {
                Debug.LogError("Tried to load profile but something went wrong. ProfileID" + profileID);
            }
        }

        return profileDictionary;
    }


    private bool AttemptRollback(string fullPath)
    {
        bool success = false;
        string backupFilePath = fullPath + backupExtension;

        try
        {
            if (File.Exists(backupFilePath))
            {
                File.Copy(backupFilePath, fullPath, true);
                success = true;

                Debug.LogWarning("Had to roll back to backup file at" + backupFilePath);
            }
            else
            {
                throw new Exception("Tried to roll back, but no backup file exists to roll back to");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error occured when trying to roll back to backup file at:" + backupFilePath + "\n" + ex);

        }

        return success;
    }
}
