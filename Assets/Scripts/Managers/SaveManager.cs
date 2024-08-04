using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static string path = Path.Combine(Application.dataPath, "Save", "Save.json");
    public GameData gameData;

    void Start()
    {
        var directory = Path.Combine(Application.dataPath, "Save");
        
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        LoadGame();
    }

    void OnDestroy()
    {
        SaveGame();
    }

    void SaveGame()
    {
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(path, json);
    }

    void LoadGame()
    {
        if (File.Exists(path))
        {
            JsonUtility.FromJsonOverwrite(File.ReadAllText(path), gameData);
            return;
        }

        return;
    }
}
