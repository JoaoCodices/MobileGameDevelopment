using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text scoreText; // Use TMP_Text for TextMeshProUGUI 
    private float time = 0.0f;

    private void Start()
    {
        // Initialize the score and update the TextMeshProUGUI Text
        time = 0.0f;
        UpdateScoreText();
    }

    private void Update()
    {
        // Increment the score based on time elapsed
        time += Time.deltaTime;

        // Update the TextMeshProUGUI Text with the new score
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // Update the TextMeshProUGUI Text element with the current score as a string
        scoreText.text = "Time: " + Mathf.RoundToInt(time).ToString();
    }
}
