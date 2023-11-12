using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGetData : MonoBehaviour
{
    int HighScore;
    int Score;
    int Time;
    int Lives;
    int Coins;
    int Theme;

    public void SaveOnClick(int _Time, int _Lives, int _HighScore,int _Score, int _Coins, int _Theme)
    {
        DataManager.Instance.HighScore = _HighScore;
        DataManager.Instance.Score = _Score;
        DataManager.Instance.Time = _Time;
        DataManager.Instance.Lives = _Lives;
        DataManager.Instance.Coins = _Coins;
        DataManager.Instance.Theme = _Theme;
        DataManager.Instance.WriteData();
    }

    public void LoadOnClick()
    {
        DataManager.Instance.LoadData();
        HighScore = DataManager.Instance.HighScore;
        Score = DataManager.Instance.Score;
        Time = DataManager.Instance.Time;
        Lives = DataManager.Instance.Lives;
        Coins = DataManager.Instance.Coins;
        Theme = DataManager.Instance.Theme;
    }
    public int LoadHighscore()
    {
        DataManager.Instance.LoadData();
        HighScore = DataManager.Instance.HighScore;
        return HighScore;
    }
    public void SaveTheme(int _Theme)
    {
        DataManager.Instance.Theme = _Theme;
        DataManager.Instance.WriteData();
    }
    public int LoadTheme()
    {
        DataManager.Instance.LoadData();
        Theme = DataManager.Instance.Theme;
        return Theme;
    }
}