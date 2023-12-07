using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public GameObject storeMenu;

    // Start is called before the first frame update
    void Start()
    {
        storeMenu.SetActive(false);

    }
    //STORE MENU
    public void OpenStore()
    {
        storeMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseStore()
    {
        storeMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
