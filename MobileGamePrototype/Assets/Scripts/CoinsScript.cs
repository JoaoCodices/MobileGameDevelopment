using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class CoinsScript : MonoBehaviour
{
    private float temp_Score;
    private int multiplier = 1;
    private int coins = 0;
    private GameObject Spawner;
    // Start is called before the first frame update
    void Start()
    {
        Spawner = GameObject.FindGameObjectWithTag("CoinsSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {            
        if (collision.gameObject.CompareTag("P1"))
        {
            temp_Score = collision.gameObject.GetComponent<Score>().score;
            temp_Score = temp_Score + 20 * multiplier;
            Spawner.GetComponent<CoinsSpawner>().Coins++;
            collision.gameObject.GetComponent<Score>().score = temp_Score;
            GameObject.Destroy(transform.gameObject);
        }
    }
}
