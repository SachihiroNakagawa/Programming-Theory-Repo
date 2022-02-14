using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Static class
/// </summary>
public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set;} // ENCAPSULATION
    public Color PlayerColor;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    [System.Serializable]
    class SaveData
    {
        public Color PlayerColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.PlayerColor = PlayerColor;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerColor = data.PlayerColor;
        }
    }
}
