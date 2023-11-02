using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Shake : MonoBehaviour
{
    //VALID ROTATION
    public  int shakeCount;
    private GameObject Manager;
    
    //rOTATION PARAMETERS
    public float rotationSpeed = 30.0f; // Set the rotation speed in degrees per second
    private float currentRotation = 0.0f;
    private bool isRotating = false;

    //BUTTON 
    private Button rotateButton;

    //public float shakeThreshold = 2.0f; // Adjust this value to set the shake sensitivity
    //private Vector3 acceleration;
    //private float originalMagnitude;

    void Start()
    {
        ////Accelerometer Input
        //originalMagnitude = Input.acceleration.magnitude;

        //VALID CHECK
        Manager = GameObject.FindGameObjectWithTag("Manager");
        shakeCount = Manager.gameObject.GetComponent<CooldownShake>().shakeCounter;

        //Button Input
        rotateButton = GameObject.FindGameObjectWithTag("RotateButton").GetComponent<Button>();
        if (rotateButton != null)
        {
            rotateButton.onClick.AddListener(StartRotation);
        }
        else
        {
            Debug.LogError("Button reference is not assigned in the Inspector.");
        }
    }

    public void StartRotation()
    {
        if (shakeCount > 0)
        {
            isRotating = true;
            Manager.gameObject.GetComponent<CooldownShake>().shakeCounter= shakeCount-1;
            shakeCount=shakeCount-1;
        }
    }

    void Update()
    {
        shakeCount = Manager.gameObject.GetComponent<CooldownShake>().shakeCounter;
        //Debug.Log(shakeCount);
        if (isRotating)
        {
            
            isRotating = true;
            // Rotate the object by the specified speed around its up axis
            transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);

            // Update the current rotation value
            currentRotation += rotationSpeed * Time.deltaTime;

            // Check if we've rotated 90 degrees, then stop rotating
            if (currentRotation >= 180.0f)
            {
                // Snap the rotation to exactly 90 degrees
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

                // Stop rotating
                isRotating = false;
                currentRotation = 0.0f;
            }
        }

        //ACCELEROMETER
        //acceleration = Input.acceleration;
        //if (IsShaking())
        //{
        //    // Call the shake event here
        //    Debug.Log("Shake detected!");

        //    //Rotate the object by the specified speed around its up axis
        //    transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);

        //    // Update the current rotation value
        //    currentRotation += rotationSpeed * Time.deltaTime;

        //    // Check if we've rotated 90 degrees, then stop rotating
        //    if (currentRotation >= 180.0f)
        //    {
        //        // Snap the rotation to exactly 90 degrees
        //        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        //        // Stop rotating
        //        isRotating = false;
        //        currentRotation = 0.0f;
        //    }
        //}
    }

    //bool IsShaking()
    //{
    //    float currentMagnitude = Input.acceleration.magnitude;
    //    float deltaMagnitudeDiff = Mathf.Abs(currentMagnitude - originalMagnitude);
    //    return deltaMagnitudeDiff >= shakeThreshold;
    //}
}

