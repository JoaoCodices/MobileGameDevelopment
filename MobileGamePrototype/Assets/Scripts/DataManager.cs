using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    //Variables that need to be stored

    [HideInInspector] public int HighScore;
    [HideInInspector] public int Score;
    [HideInInspector] public int Time;
    [HideInInspector] public int Lives;
    [HideInInspector] public int Coins;
    [HideInInspector] public int Theme;

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
        public int Score;
        public int Time;
        public int Lives;
        public int Coins;
        public int Theme;
    }

    public void WriteData()
    {
        SaveData data = new SaveData();

        //Variables that need to be stored
        data.HighScore = HighScore;
        data.Score = Score;
        data.Time = Time;
        data.Lives = Lives;
        data.Coins = Coins;
        data.Theme = Theme;

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
            Score = data.Score;
            Time = data.Time;
            Lives = data.Lives;
            Coins = data.Coins;
            Theme = data.Theme;
        }
    }
}
