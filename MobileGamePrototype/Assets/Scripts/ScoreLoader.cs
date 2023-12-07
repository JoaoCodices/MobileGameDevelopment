using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreLoader : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;
    private int highscore;
    private GameObject Manager;
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("DataManager");
        score = Manager.GetComponent<SetGetData>().LoadScore();
        highscore = Manager.GetComponent<SetGetData>().LoadHighscore();

        if (score > highscore)
        {
            scoreText.text = "New Highscore: " + score;
        }
        else
        {
            scoreText.text = "Score: " + score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
