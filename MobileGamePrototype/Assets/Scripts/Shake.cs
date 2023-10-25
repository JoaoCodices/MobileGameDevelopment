using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.UI;

//public class Shake : MonoBehaviour
//{
//    public float rotationSpeed = 30.0f; // Set the rotation speed in degrees per second
//    private float currentRotation = 0.0f;
//    private bool isRotating = false;

//    // Add a reference to the button in the Inspector
//    private Button rotateButton;


//    private void Start()
//    {
//        rotateButton = GameObject.FindGameObjectWithTag("RotateButton").GetComponent<Button>();
//        if (rotateButton != null)
//        {
//            rotateButton.onClick.AddListener(StartRotation);
//        }
//        else
//        {
//            Debug.LogError("Button reference is not assigned in the Inspector.");
//        }
//    }

//    private void Update()
//    {
//        if (isRotating)
//        {
//            // Rotate the object by the specified speed around its up axis
//            transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);

//            // Update the current rotation value
//            currentRotation += rotationSpeed * Time.deltaTime;

//            // Check if we've rotated 90 degrees, then stop rotating
//            if (currentRotation >= 180.0f)
//            {
//                // Snap the rotation to exactly 90 degrees
//                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

//                // Stop rotating
//                isRotating = false;
//                currentRotation = 0.0f;
//            }
//        }
//    }

//    // Function to start the rotation when the button is clicked
//    public void StartRotation()
//    {
//        isRotating = true;
//    }
//}


public class Shake : MonoBehaviour
{

    public float rotationSpeed = 30.0f; // Set the rotation speed in degrees per second
    private float currentRotation = 0.0f;
    private bool isRotating = false;

    private Button rotateButton;

    public float shakeThreshold = 2.0f; // Adjust this value to set the shake sensitivity
    private Vector3 acceleration;
    private float originalMagnitude;

    void Start()
    {
        //Accelerometer Input
        originalMagnitude = Input.acceleration.magnitude;

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
        isRotating = true;
    }

    void Update()
    {

        if (isRotating)
        {
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

        acceleration = Input.acceleration;
        if (IsShaking())
        {
            // Call the shake event here
            Debug.Log("Shake detected!");

            //Rotate the object by the specified speed around its up axis
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
    }

    bool IsShaking()
    {
        float currentMagnitude = Input.acceleration.magnitude;
        float deltaMagnitudeDiff = Mathf.Abs(currentMagnitude - originalMagnitude);
        return deltaMagnitudeDiff >= shakeThreshold;
    }
}

