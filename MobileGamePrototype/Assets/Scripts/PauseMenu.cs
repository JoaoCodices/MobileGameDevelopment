using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using UnityEngine.SocialPlatforms.Impl;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenu;
    public GameObject storeMenu;
    public GameObject settingsMenu;
    public Button pauseButton;
    public Button storeButton;
    public Button themeButton;
    public TMP_Text soundButton;


    public Camera MyCamera;

    private int Theme = 0;
    //Base
    public Material Colour_0;
    //Primary
    public Material Colour_1;
    //Secondary
    public Material Colour_2;


    public Material TileMat;

    public Texture2D Tex_0;
    public Texture2D Tex_1;
    public Texture2D Tex_2;
    public Texture2D Tex_3;

    Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        storeMenu.SetActive(false);
        settingsMenu.SetActive(false);
        pauseButton.onClick.AddListener(PauseGame);
        storeButton.onClick.AddListener(OpenStore);
        TileMat.mainTexture = Tex_0;

       

        Debug.Log("Theme n: " +  Theme);
        Colour_1.color = new Color(0.961f,0.816f, 0.541f, 1.0f);
        Colour_2.color = new Color(0.643f, 0.502f, 0.263f, 1.0f);
        //Base Colour
        Colour_0.color = new Color(0.988f, 0.941f, 0.765f);
        //Camera Background

        scene = SceneManager.GetActiveScene();
        if (scene.name == "IntroScene")
        {
            MyCamera.backgroundColor = new Color(0.961f, 0.816f, 0.541f);
            
        }
        else
        {
            MyCamera.backgroundColor = new Color(0.988f, 0.941f, 0.765f);
        }
        
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

                TileMat.mainTexture = Tex_0;
                Colour_0.color = new Color(0.988f, 0.941f, 0.765f);
                if (scene.name == "MainScene")
                {
                    MyCamera.backgroundColor = new Color(0.988f, 0.941f, 0.765f);
                }
                else
                {
                    MyCamera.backgroundColor = new Color(0.961f, 0.816f, 0.541f);
                }
                Debug.Log("Active 1");
                break;
            //PURPLE
            case 1:
                Colour_1.color = new Color(0.757f, 0.537f, 0.961f, 1.0f);
                Colour_2.color = new Color(0.451f, 0.263f, 0.639f, 1.0f);

                TileMat.mainTexture = Tex_1;
                Colour_0.color = new Color(0.906f, 0.761f, 0.949f);

                MyCamera.backgroundColor = new Color(0.906f, 0.761f, 0.949f);
                Debug.Log("Active 2");
                break;
            //GREEN
            case 2:
                Colour_1.color = new Color(0.741f, 0.961f, 0.537f, 1.0f);
                Colour_2.color = new Color(0.451f, 0.639f, 0.263f, 1.0f);

                TileMat.mainTexture = Tex_2;
                Colour_0.color = new Color(0.843f, 0.988f, 0.761f);
                MyCamera.backgroundColor = new Color(0.843f, 0.988f, 0.761f);
                Debug.Log("Active 3");
                break;
            //BLUE
            case 3:
                Colour_1.color = new Color(0.537f, 0.686f, 0.961f, 1.0f);
                Colour_2.color = new Color(0.263f, 0.4f, 0.639f, 1.0f);

                TileMat.mainTexture = Tex_3;
                Colour_0.color = new Color(0.761f, 0.812f, 0.988f);
                MyCamera.backgroundColor = new Color(0.761f, 0.812f, 0.988f);
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
        storeMenu.SetActive(false);
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

    //STORE MENU
    public void OpenStore()
    {
        storeMenu.SetActive(true);
        Time.timeScale = 0f;
    }


}
