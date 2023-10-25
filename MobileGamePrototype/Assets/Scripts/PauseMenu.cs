using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public Button pauseButton;
    public TMP_Text soundButton;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        pauseButton.onClick.AddListener(PauseGame);
    }

    // Update is called once per frame
   

    //PAUSE MENU
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void MainScene()
    {
        SceneManager.LoadScene(0);
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    //SETTINGS MENU
    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }
    public void SoundControl()
    {
        if(soundButton.text == "Sound On")
        {
            soundButton.text = "Sound Off";
        }else if(soundButton.text == "Sound Off")
        {
            soundButton.text = "Sound On";
        }

    }
}
