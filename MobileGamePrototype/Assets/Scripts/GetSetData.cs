using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGetData : MonoBehaviour
{
    public int HighScore;
    public int Time;
    public int Lives;

    // Start is called before the first frame update void Start(){}
    // Update is called once per frame void Update(){}

    public void SaveOnClick(int _Lives, int _Time, int _HighScore)
    {
        DataManager.Instance.HighScore = _HighScore;
        DataManager.Instance.Time = _Time;
        DataManager.Instance.Lives = _Lives;
        DataManager.Instance.WriteData();
    }

    public void LoadOnClick()
    {
        DataManager.Instance.LoadData();
        HighScore = DataManager.Instance.HighScore;
        Time = DataManager.Instance.Time;
        Lives = DataManager.Instance.Lives;
    }
    public int LoadHighscore()
    {
        DataManager.Instance.LoadData();
        HighScore = DataManager.Instance.HighScore;
        return HighScore;
    }
}