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
    int ShowAds;

    public void SaveAllData(int _Time, int _Lives, int _HighScore,int _Score, int _Coins, int _Theme, int _ShowAds)
    {
        DataManager.Instance.HighScore = _HighScore;
        DataManager.Instance.Score = _Score;
        DataManager.Instance.Time = _Time;
        DataManager.Instance.Lives = _Lives;
        DataManager.Instance.Coins = _Coins;
        DataManager.Instance.Theme = _Theme;
        DataManager.Instance.ShowAds = _ShowAds;
        DataManager.Instance.WriteData();
    }
    public void LoadAllData()
    {
        DataManager.Instance.LoadData();
        HighScore = DataManager.Instance.HighScore;
        Score = DataManager.Instance.Score;
        Time = DataManager.Instance.Time;
        Lives = DataManager.Instance.Lives;
        Coins = DataManager.Instance.Coins;
        Theme = DataManager.Instance.Theme;
        ShowAds = DataManager.Instance.ShowAds;
    }

    public void SaveOnDeath(int _Time, int _Lives, int _HighScore, int _Score, int _Coins)
    {
        DataManager.Instance.HighScore = _HighScore;
        DataManager.Instance.Score = _Score;
        DataManager.Instance.Time = _Time;
        DataManager.Instance.Lives = _Lives;
        DataManager.Instance.Coins = _Coins;
        DataManager.Instance.WriteData();
    }

    //COINS
    public int LoadCoins()
    {
        DataManager.Instance.LoadData();
        Coins = DataManager.Instance.Coins;
        return Coins;
    }
    public void SaveCoins(int _Coins)
    {
        DataManager.Instance.Coins = _Coins;
        DataManager.Instance.WriteData();
    }
    //ADS
    public int LoadAds() 
    { 
        DataManager.Instance.LoadData();
        ShowAds = DataManager.Instance.ShowAds;
        return ShowAds;
    }
    public void SaveAds(int _ShowAds)
    {
        DataManager.Instance.ShowAds = _ShowAds;
        DataManager.Instance.WriteData();
    }
    //HIGHSCORE
    public int LoadHighscore()
    {
        DataManager.Instance.LoadData();
        HighScore = DataManager.Instance.HighScore;
        return HighScore;
    }
    public void SaveHighscore(int _Highscore)
    {
        DataManager.Instance.HighScore = _Highscore;
        DataManager.Instance.WriteData();
    }
    //SCORE
    public int LoadScore()
    {
        DataManager.Instance.LoadData();
        Score = DataManager.Instance.Score;
        return Score;
    }
    public void SaveScore(int _Score) 
    { 
        DataManager.Instance.Score = _Score;
        DataManager.Instance.WriteData();
    }
    //THEME
    public int LoadTheme()
    {
        DataManager.Instance.LoadData();
        Theme = DataManager.Instance.Theme;
        return Theme;
    }
    public void SaveTheme(int _Theme)
    {
        DataManager.Instance.Theme = _Theme;
        DataManager.Instance.WriteData();
    }

}