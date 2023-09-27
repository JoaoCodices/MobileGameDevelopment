using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText; // Use TMP_Text for TextMeshProUGUI
    public float scoreRate = 1.0f; // Score increase rate in points per second
    private float score = 0.0f;

    private void Start()
    {
        // Initialize the score and update the TextMeshProUGUI Text
        score = 0.0f;
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
        scoreText.text = "Score: " + Mathf.RoundToInt(score).ToString();
    }
}
