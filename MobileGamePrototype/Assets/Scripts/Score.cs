using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    //UI
    public TMP_Text scoreText;
    public TMP_Text coinsText;
    public TMP_Text hsText;
    public TMP_Text livesText;
    //STORE
    public TMP_Text StorelivesText;
    public TMP_Text StorecoinsText;
    //
    public float scoreRate = 1.0f; // Score increase rate in points per second
    public float score = 0.0f;
    private int highScore;
    public int lives = 3;
    public int coins;
    //
    private GameObject Manager;

    private void Start()
    {
        // Initialize the score and update the TextMeshProUGUI Text
        score = 0.0f;
        lives = 3;

        Manager = GameObject.FindGameObjectWithTag("Manager");

        highScore = Manager.GetComponent<SetGetData>().LoadHighscore();
        UpdateScoreText();
    }

    private void Update()
    {
        // Increment the score based on time elapsed
        score += scoreRate * Time.deltaTime;

        // Update the TextMeshProUGUI Text with the new score
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // Update the TextMeshProUGUI Text element with the current score as a string
        //int Score =  Manager.GetComponent<SetGetData>().LoadHighscore();
        hsText.text = "HS: " + Mathf.RoundToInt(highScore).ToString();
        scoreText.text = "SCORE: " + Mathf.RoundToInt(score).ToString();
        livesText.text = "" + Mathf.RoundToInt(lives).ToString();
        StorelivesText.text = "LIVES: " + Mathf.RoundToInt(lives).ToString();
        coinsText.text= "COINS: " + Mathf.RoundToInt(coins).ToString();
        StorecoinsText.text = "COINS: " + Mathf.RoundToInt(coins).ToString();
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
            Manager.gameObject.GetComponent<CooldownShake>().shakeCounter ++;
        }
    }

    public void StoreScore()
    {
        if (score > highScore)
        {
            this.GetComponent<SetGetData>().SaveOnClick((int)Time.deltaTime, lives, (int)score);
            Debug.Log("New HighScore");
        }
    }
}
