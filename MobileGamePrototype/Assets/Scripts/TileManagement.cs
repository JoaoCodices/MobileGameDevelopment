using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TileManagement : MonoBehaviour
{
    GameObject[] Tiles;
    Rigidbody[] rbs;
    public bool Valid = false;
    public bool Reverse = false;
    public float rotationSpeed = 90.0f; // The speed at which the rotation will occur

    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private Quaternion reverseRotation;
    private Coroutine rotationCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        Tiles = GameObject.FindGameObjectsWithTag("Tile");
        rbs = new Rigidbody[Tiles.Length];



        for(int i = 0 ; i<Tiles.Length ; i++)
        {
            GameObject tile = Tiles[i];

            rbs[i] = tile.GetComponent<Rigidbody>();
        }
    }
    public void Rotate()
    {
        if (!Valid)
        {
            foreach(Rigidbody rb in rbs)
            {
                initialRotation = rb.rotation;
                targetRotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(0, 0, 180f));
            }
            Valid = true;
        }
    }
    private void FixedUpdate()
    {
        if (Valid)
        {
            RotationFwd();
        }
    }
    private void RotationFwd()
    {
        float step = rotationSpeed * Time.deltaTime;
        foreach (Rigidbody rb in rbs)
        {
            rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, step));
            if (rb.rotation == targetRotation)
            {
                Valid = false;
            }
        }
    }
}
