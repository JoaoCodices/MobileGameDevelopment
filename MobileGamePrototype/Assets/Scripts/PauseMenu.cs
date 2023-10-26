using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public Button pauseButton;
    public Button themeButton;
    public TMP_Text soundButton;

    private int Theme = 0;

    //Primary
    public Material Colour_1;
    //Secondary
    public Material Colour_2;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        pauseButton.onClick.AddListener(PauseGame);

        Debug.Log("Theme n: " +  Theme);
        Colour_1.color = new Color(0.961f,0.816f, 0.541f, 1.0f);
        Colour_2.color = new Color(0.643f, 0.502f, 0.263f, 1.0f);

    }

    public void ChangeTheme()
    {
        if (Theme < 3)
        {
            Theme++;
            Debug.Log("Theme n: " + Theme);
        }
        else if (Theme == 3) 
        { 
            Theme = 0;
            Debug.Log("Theme n: " + Theme);
        }

        switch (Theme)
        {
            //BASE
            case 0:
                Colour_1.color = new Color(0.961f, 0.816f, 0.541f, 1.0f);
                Colour_2.color = new Color(0.643f, 0.502f, 0.263f, 1.0f);
                Debug.Log("Active 1");
                break;
            //PURPLE
            case 1:
                Colour_1.color = new Color(0.961f, 0.816f, 0.541f, 1.0f);
                Colour_2.color = new Color(0.643f, 0.502f, 0.263f, 1.0f);
                Debug.Log("Active 2");
                break;
            //GREEN
            case 2:
                Colour_1.color = new Color(0.961f, 0.816f, 0.541f, 1.0f);
                Colour_2.color = new Color(0.643f, 0.502f, 0.263f, 1.0f);
                Debug.Log("Active 3");
                break;
            //BLUE
            case 3:
                Colour_1.color = new Color(0.961f, 0.816f, 0.541f, 1.0f);
                Colour_2.color = new Color(0.643f, 0.502f, 0.263f, 1.0f);
                Debug.Log("Active 4");
                break;

        }


        //if(Theme == 0)
        //{
        //    pauseButton.image.color = Colour_1;
        //    Debug.Log("Active 1");
        //}
        //pauseButton.image.color = Colour_1;
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
