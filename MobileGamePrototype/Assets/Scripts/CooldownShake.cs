using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CooldownShake : MonoBehaviour
{
    public float time;
    public TMP_Text cdText;
    public TMP_Text StoreshakeText;
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
        StoreshakeText.text= "Shakes: " + shakeCounter;

        time -= Time.deltaTime;
        if (shakeCounter == 0)
        {
            cdText.text = "" + (int)time;
            cdText.color = new Color(0f,0f,0f, 0.3411765f);
        }
        else
        {
            cdText.text = "" + shakeCounter;
            cdText.color = Color.white;
        }
        Fill.fillAmount = time / max;
        if (time < 0)
        {
            time = max;
            shakeCounter++;           
        }
    }

}
