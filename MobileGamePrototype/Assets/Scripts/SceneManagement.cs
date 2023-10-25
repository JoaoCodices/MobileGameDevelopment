using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class SceneManagement : MonoBehaviour
{
    public GameObject player;

    public TMP_Text hsText;

    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = this.GetComponent<SetGetData>().LoadHighscore();
        hsText.text = "HS: " + Mathf.RoundToInt(score).ToString();
    }
    public void OnPlay()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        int score = this.GetComponent<SetGetData>().LoadHighscore();
        hsText.text = "HS: " + Mathf.RoundToInt(score).ToString();

        
    }
    // Update is called once per frame
        void Update()
        {
            if (player.GetComponent<Score>().lives <= 0)
            {
                if(player.GetComponent<Score>().score > score) 
                {
                    this.GetComponent<SetGetData>().SaveOnClick((int)Time.deltaTime, player.GetComponent<Score>().lives, (int)player.GetComponent<Score>().score);
                    Debug.Log("New HighScore");
                }
                
                SceneManager.LoadScene(2, LoadSceneMode.Single);
            }

        }
}
