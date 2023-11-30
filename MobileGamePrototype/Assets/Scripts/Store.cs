using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public GameObject storeMenu;
    public TMP_Text StorelivesText;
    public TMP_Text StorecoinsText;
    public TMP_Text StoreclearsText;

    // Start is called before the first frame update
    void Start()
    {
        storeMenu.SetActive(false);
        StorelivesText.text = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("P1").GetComponent<Score>().lives).ToString();
        StorecoinsText.text = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("P1").GetComponent<Score>().coins).ToString();
        StoreclearsText.text = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("Map").GetComponent<CooldownShake>().shakeCounter).ToString();
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
