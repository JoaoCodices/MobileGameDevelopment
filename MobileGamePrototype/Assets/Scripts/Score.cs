using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Analytics;
using UnityEditor;

public class Score : MonoBehaviour
{
    //UI
    public TMP_Text scoreText;
    public TMP_Text coinsText;
    public TMP_Text hsText;
    public TMP_Text livesText;

    public TMP_Text StorelivesText;
    public TMP_Text StorecoinsText;
    public TMP_Text StoreclearsText;
    //
    public float scoreRate = 1.0f; // Score increase rate in points per second
    public float score = 0.0f;
    private int highScore;
    public int lives = 3;
    public int coins;
    //
    private GameObject Manager;
    //LOSS SYSTEM
    public GameObject Gameover;
    public GameObject shakeController;
    public bool firstLoss = true;

    private void Start()
    {
        Time.timeScale = 1f;
        // Initialize the score and update the TextMeshProUGUI Text
        score = 0.0f;
        lives = 3;
        Manager = GameObject.FindGameObjectWithTag("DataManager");
        highScore = Manager.GetComponent<SetGetData>().LoadHighscore();
        UpdateScoreText();
    }

    private void Update()
    {
        // Increment the score based on time elapsed
        score += scoreRate * Time.deltaTime;

        // Update the TextMeshProUGUI Text with the new score
        UpdateScoreText();


        if (lives <= 0 && firstLoss == true)
        {
            RewardADMenu();
        }
        else if (lives <= 0 && firstLoss == false)
        {
            GameLoss();
        }

    }
    public void RemoveLife()
    {
        lives--;
    }
    public void RewardADMenu()
    {
        Debug.Log("WATCH AD MENU");
        Time.timeScale = 0f;
        Gameover.SetActive(true); 
    }
    public void ExtraLife()
    {
        Debug.Log("REWARD AD +1 LIFE");
        lives++;
        Time.timeScale = 1f;
        Gameover.SetActive(false);
        firstLoss = false;
    }
    private void UpdateScoreText()
    {
        // Update the TextMeshProUGUI Text element with the current score as a string
        hsText.text = "HS: " + Mathf.RoundToInt(highScore).ToString();
        scoreText.text = "SCORE: " + Mathf.RoundToInt(score).ToString();
        livesText.text = "" + Mathf.RoundToInt(lives).ToString();
        coinsText.text= "" + Mathf.RoundToInt(coins).ToString();

        StorelivesText.text = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("P1").GetComponent<Score>().lives).ToString();
        StorecoinsText.text = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("P1").GetComponent<Score>().coins).ToString();
        StoreclearsText.text = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("Map").GetComponent<CooldownShake>().shakeCounter).ToString();
    }
    public void BuyLives()
    {
        if (coins >= 10)
        {
            coins -= 10;
            lives++;
        }
    }
    public void BuyShakes()
    {
        if (coins >= 5)
        {
            coins -= 5;
            shakeController.gameObject.GetComponent<CooldownShake>().shakeCounter++;
        }
    }

    public void GameLoss()
    {
        if (score > highScore)
        {
            highScore = (int)score;
            Debug.Log("New HighScore: " + highScore);
            Manager.GetComponent<SetGetData>().SaveOnDeath((int)Time.deltaTime, lives, highScore, (int)score, coins);
        }
        else
        {
            Debug.Log("You didn't beat your Highscore of: " + highScore);
            Manager.GetComponent<SetGetData>().SaveOnDeath((int)Time.deltaTime, lives, highScore, (int)score, coins);
        }
        GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManagement>().LoadLoss();
    }
}
