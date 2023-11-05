using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Shake : MonoBehaviour
{

    Rigidbody rb;
    public float rotationSpeed = 90.0f; // The speed at which the rotation will occur

    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private bool isReversing = false;
    private Coroutine rotationCoroutine;


    //VALID ROTATION
    public  int shakeCount;
    private GameObject Manager;
    
    //rOTATION PARAMETERS
    //public float rotationSpeed = 30.0f; // Set the rotation speed in degrees per second
    private float currentRotation = 0.0f;
    public bool isRotating = false;

    //BUTTON 
    private Button rotateButton;

    //public float shakeThreshold = 2.0f; // Adjust this value to set the shake sensitivity
    //private Vector3 acceleration;
    //private float originalMagnitude;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        initialRotation = rb.rotation;
        targetRotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(0, 0, 180f));

        // Start the rotation coroutine
        //StartCoroutine(RotateSequence());


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

    private IEnumerator RotateSequence()
    {
        while (true)
        {
            float step = rotationSpeed * Time.deltaTime;

            if (!isReversing)
            {
                // Rotate towards the target rotation
                rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, step));

                // Check if the target rotation is reached, then reverse the rotation
                if (rb.rotation == targetRotation)
                {
                    isReversing = true;
                    yield return new WaitForSeconds(0.5f); // Delay before reversing the rotation
                }
            }
            else
            {
                // Rotate back to the initial rotation
                rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, initialRotation, step));

                // Check if the initial rotation is reached, then reset the reversing flag and stop the coroutine
                if (rb.rotation == initialRotation)
                {
                    isReversing = false;
                    yield return new WaitForSeconds(1.0f); // Delay before rotating again
                    StopRotation();
                }
            }

            yield return null;
        }
    }

    public void StartRotationC()
    {
        if (rotationCoroutine == null)
            rotationCoroutine = StartCoroutine(RotateSequence());
    }

    public void StopRotation()
    {
        if (rotationCoroutine != null)
        {
            StopCoroutine(rotationCoroutine);
            rotationCoroutine = null;
            isRotating = false;
            Debug.Log("Rotation Finished");
        }
    }
    public void StartRotation()
    {
        if (shakeCount > 0)
        {
            isRotating = true;
            Manager.gameObject.GetComponent<CooldownShake>().shakeCounter= shakeCount-1;
            shakeCount=shakeCount-1;
            StartRotationC();
        }
    }

    void FixedUpdate()
    {
        shakeCount = Manager.gameObject.GetComponent<CooldownShake>().shakeCounter;
        //Debug.Log(shakeCount);
        if (isRotating)
        {
            //StartCoroutine(RotateSequence());
            isRotating = false;
            //if (currentLerpTime < rotationDuration)
            //{
            //    // Increment the lerp time
            //    currentLerpTime += Time.deltaTime;

            //    // Calculate the Lerp value
            //    float t = currentLerpTime / rotationDuration;

            //    // Choose the target rotation based on the current state
            //    Quaternion target = isReturning ? initialRotation : targetRotation;

            //    // Lerp the rotation
            //    Quaternion newRotation = Quaternion.Slerp(initialRotation, target, t);

            //    // Apply the new rotation to the Rigidbody
            //    rb.MoveRotation(newRotation);

            //    // If we have reached the target rotation, toggle the state and reset the lerp time
            //    if (t >= 1.0f)
            //    {
            //        isReturning = !isReturning;
            //        isRotating = false;
            //        currentLerpTime = 0.0f;
            //    }
            //}


            //isRotating = true;
            //// Rotate the object by the specified speed around its up axis
            //transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);

            //// Update the current rotation value
            //currentRotation += rotationSpeed * Time.deltaTime;

            //// Check if we've rotated 90 degrees, then stop rotating
            //if (currentRotation >= 180.0f)
            //{
            //    // Snap the rotation to exactly 90 degrees
            //    transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            //    // Stop rotating
            //    isRotating = false;
            //    currentRotation = 0.0f;
            //}
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

