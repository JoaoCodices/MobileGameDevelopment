using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class SceneManagement : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       //SetPlayer();
    }
    public void OnPlay()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        SetPlayer();
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void OnLoss()
    {
        SetPlayer();
        if (player.GetComponent<Score>().lives <= 0)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }
    public void SetPlayer()
    {
        player = GameObject.FindGameObjectWithTag("P1");
        if (player != null)
        {       
            
        }
        else
        {
            Debug.LogError("No Player Found!");
        }
    }
    public void BacktoStart()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
