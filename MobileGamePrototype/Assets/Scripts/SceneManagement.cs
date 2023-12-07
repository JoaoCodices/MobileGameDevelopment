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
    }
    public void LoadMain()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void LoadLoss()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
    public void LoadIntro()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
