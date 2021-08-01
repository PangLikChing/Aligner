using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    //Initialize
    public static readonly string SAVE_FOLDER = Application.persistentDataPath + "/Saves/";

    public static void Init()
    {
        //if Save folder doesn't exist
        if (!Directory.Exists(SAVE_FOLDER))
        {
            //Create Save Folder
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void Save(string saveString)
    {
        int saveNumber = 1;

        //Find the smallest possible saveNumber
        while (File.Exists(SAVE_FOLDER + "save_" + saveNumber + ".json"))
        {
            saveNumber++;
        }

        //Save a new save at the smallest possible saveNumber file
        File.WriteAllText(SAVE_FOLDER + "save_" + saveNumber + ".json", saveString);
    }

    public static string Load()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles("*.json");
        FileInfo mostRecentFile = null;
        
        //Find the latest written file
        foreach (FileInfo fileInfo in saveFiles)
        {
            if (mostRecentFile == null)
            {
                mostRecentFile = fileInfo;
            }
            else
            {
                if (fileInfo.LastWriteTime > mostRecentFile.LastWriteTime)
                {
                    mostRecentFile = fileInfo;
                }
            }
        }

        if (mostRecentFile != null){
            int saveNumber = 1;
            string savedString = File.ReadAllText(mostRecentFile.FullName);

            //Delete previous saves except the most recent file
            while (File.Exists(SAVE_FOLDER + "save_" + saveNumber + ".json"))
            {
                saveNumber++;
            }

            for (int i = 1; i < saveNumber - 1; i++)
            {
                File.Delete(SAVE_FOLDER + "save_" + i + ".json");
            }

            int previousSaveNumber = saveNumber - 1;
            //Write the latest file at save_1.json
            File.WriteAllText(SAVE_FOLDER + "save_" + 1 + ".json", File.ReadAllText(SAVE_FOLDER + "save_" + previousSaveNumber + ".json"));
            //Don't delete if previousSaveNumber is 1 or below
            if (previousSaveNumber > 1)
            {
                File.Delete(SAVE_FOLDER + "save_" + previousSaveNumber + ".json");
            }

            return savedString;
        }
        else
        {
            return null;
        }
    }
}