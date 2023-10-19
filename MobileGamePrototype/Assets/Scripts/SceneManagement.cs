using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnPlay()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Score>().lives <= 0) { SceneManager.LoadScene(2, LoadSceneMode.Single); }
        
    }
}
