using UnityEngine;
using UnityEngine.SceneManagement;

public class AdsIntro : MonoBehaviour
{
    
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "IntroScene")
        {
            Debug.Log("IntroScene");
            GetComponent<AdsBanner>().enabled = true;
        }
    }
}
