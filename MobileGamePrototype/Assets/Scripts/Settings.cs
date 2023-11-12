using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public GameObject settingsMenu;

    //THEME
    Scene scene;
    Camera MyCamera;
    private int Theme = 0;
    public Material Colour_0;
    public Material Colour_1;
    public Material Colour_2;
    public Material TileMat;
    public Texture2D Tex_0;
    public Texture2D Tex_1;
    public Texture2D Tex_2;
    public Texture2D Tex_3;

    // Start is called before the first frame update
    void Start()
    {
        settingsMenu.SetActive(false);
        SetTheme();
    }
    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }

    //THEME
    private void Update()
    {
    }
    public void SetTheme()
    {
        Theme = this.GetComponent<SetGetData>().LoadTheme();

        MyCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Colour_1.color = new Color(0.961f, 0.816f, 0.541f, 1.0f);
        Colour_2.color = new Color(0.643f, 0.502f, 0.263f, 1.0f);
        Colour_0.color = new Color(0.988f, 0.941f, 0.765f);
        scene = SceneManager.GetActiveScene();
        ThemeSwitch(Theme);
    }
    public void ChangeTheme()
    {
        if (Theme < 3)
        {
            Theme++;
        }
        else if (Theme == 3)
        {
            Theme = 0;
        }
        Debug.Log("Current Theme: " + Theme);
        ThemeSwitch(Theme);
    }
    public void ThemeSwitch(int _Theme)
    {
        switch (_Theme)
        {
            //CREAM
            case 0:
                MyCamera.backgroundColor = new Color(0.988f, 0.941f, 0.765f);
                Colour_0.color = new Color(0.988f, 0.941f, 0.765f);
                Colour_1.color = new Color(0.961f, 0.816f, 0.541f, 1.0f);
                Colour_2.color = new Color(0.643f, 0.502f, 0.263f, 1.0f);
                TileMat.mainTexture = Tex_0;
                Debug.Log("Cream Theme");
                this.GetComponent<SetGetData>().SaveTheme(Theme);
                break;
            //PURPLE
            case 1:
                MyCamera.backgroundColor = new Color(0.906f, 0.761f, 0.949f);
                Colour_0.color = new Color(0.906f, 0.761f, 0.949f);
                Colour_1.color = new Color(0.757f, 0.537f, 0.961f, 1.0f);
                Colour_2.color = new Color(0.451f, 0.263f, 0.639f, 1.0f);
                TileMat.mainTexture = Tex_1;
                Debug.Log("Purple Theme");
                this.GetComponent<SetGetData>().SaveTheme(Theme);
                break;
            //GREEN
            case 2:
                MyCamera.backgroundColor = new Color(0.843f, 0.988f, 0.761f);
                Colour_0.color = new Color(0.843f, 0.988f, 0.761f);
                Colour_1.color = new Color(0.741f, 0.961f, 0.537f, 1.0f);
                Colour_2.color = new Color(0.451f, 0.639f, 0.263f, 1.0f);
                TileMat.mainTexture = Tex_2;
                Debug.Log("Green Theme");
                this.GetComponent<SetGetData>().SaveTheme(Theme);
                break;
            //BLUE
            case 3:
                MyCamera.backgroundColor = new Color(0.761f, 0.812f, 0.988f);
                Colour_0.color = new Color(0.761f, 0.812f, 0.988f);
                Colour_1.color = new Color(0.537f, 0.686f, 0.961f, 1.0f);
                Colour_2.color = new Color(0.263f, 0.4f, 0.639f, 1.0f);
                TileMat.mainTexture = Tex_3;
                Debug.Log("Blue Theme");
                this.GetComponent<SetGetData>().SaveTheme(Theme);
                break;
        }
    }
}

