using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CooldownShake : MonoBehaviour
{
    private GameObject[] Shake;
    public float time;
    public TMP_Text cdText;
    public Image Fill;
    public float max;
    public int shakeCounter;

    // Start is called before the first frame update
    void Start()
    {
        shakeCounter = 3;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (shakeCounter == 0)
        {
            cdText.text = "" + (int)time;
            cdText.color = new Color(0f,0f,0f, 0.3411765f);
        }
        else
        {
            cdText.text = "" + shakeCounter;
            cdText.color = new Color(0.643f, 0.502f, 0.263f, 1f);
        }
        Fill.fillAmount = time / max;
        if (time < 0)
        {
            time = max;
            shakeCounter++;
            Shake = GameObject.FindGameObjectsWithTag("Tile");
            
        }
    }
}
