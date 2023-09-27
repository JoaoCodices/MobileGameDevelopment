using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shake : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Set the rotation speed in degrees per second
    private float currentRotation = 0.0f;
    private bool isRotating = false;

    // Add a reference to the button in the Inspector
    public Button rotateButton;


    private void Start()
    {
        if (rotateButton != null)
        {
            rotateButton.onClick.AddListener(StartRotation);
        }
        else
        {
            Debug.LogError("Button reference is not assigned in the Inspector.");
        }
    }

    private void Update()
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
    }

    // Function to start the rotation when the button is clicked
    private void StartRotation()
    {
        isRotating = true;
    }
}
