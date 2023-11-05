using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    //Variables that need to be stored

    public int HighScore;
    public int Time;
    public int Lives;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    class SaveData
    {
        //Variables that need to be stored

        public int HighScore;
        public int Time;
        public int Lives;
    }

    public void WriteData()
    {
        SaveData data = new SaveData();

        //Variables that need to be stored
        data.HighScore = HighScore;
        data.Time = Time;
        data.Lives = Lives;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("Application.persistentDataPath: " + Application.persistentDataPath);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            //Variables that need to be stored
            HighScore = data.HighScore;
            Time = data.Time;
            Lives = data.Lives;
        }
    }
}
