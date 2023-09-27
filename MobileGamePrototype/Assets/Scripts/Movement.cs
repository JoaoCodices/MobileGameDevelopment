using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private bool isSwiping = false;
    public float moveDistance = 1.2f; // Adjust this value to change the distance the object moves.

    private float lastTapTime;
    public float jumpForce = 5.0f; // Adjust this value to control the jump force.
    public float doubleTapInterval = 0.3f; // Adjust this value for your desired double-tap timing.

    Rigidbody rb; // Assuming the player has a Rigidbody

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Check for double-tap input.
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            // Check if it's the second tap within the doubleTapInterval.
            if (touch.phase == TouchPhase.Began && Time.time - lastTapTime < doubleTapInterval)
            {
                // Perform the jump action when a double tap is detected.
                if (transform.position.y < 0.67f)
                {
                    Jump();
                    Debug.Log("Double Tap");
                }
            }
            else
            {
                lastTapTime = Time.time;
            }
        }
        void Jump()
        {
            // Ensure the Rigidbody2D component exists.
            if (rb != null)
            {
                // Apply an upward force to make the player jump.
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        // Check for touch input.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Detect the beginning of a swipe.
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                isSwiping = true;
            }

            // Detect the end of a swipe.
            if (touch.phase == TouchPhase.Ended)
            {
                touchEndPos = touch.position;
                isSwiping = false;

                // Calculate the swipe direction vector.
                Vector2 swipeDirection = touchEndPos - touchStartPos;



                // Check if the swipe distance is greater than a threshold (to avoid accidental swipes).
                if (swipeDirection.magnitude >= 50.0f) // Adjust the threshold as needed.
                {
                    float absX = Mathf.Abs(swipeDirection.x);
                    float absY = Mathf.Abs(swipeDirection.y);
                    Debug.Log(swipeDirection);
                    //X-AXIS
                    //Right
                    if (absX > absY && swipeDirection.x > 0.0f && transform.position.x < 2.4f)
                    {
                        Vector3 targetPosition = transform.position + new Vector3(moveDistance, 0, 0);

                        // Move the GameObject to the target position.
                        transform.position = targetPosition;
                    }
                    //Left
                    else if (absX > absY && swipeDirection.x < 0.0f && transform.position.z > -2.4f)
                    {
                        Vector3 targetPosition = transform.position + new Vector3(moveDistance * -1, 0, 0);

                        // Move the GameObject to the target position.
                        transform.position = targetPosition;
                    }
                    //Z-AXIS
                    //Left
                    if (absX < absY && swipeDirection.y > 0.0f && transform.position.z < 2.4f)
                    {
                        Vector3 targetPosition = transform.position + new Vector3(0, 0, moveDistance);

                        // Move the GameObject to the target position.

                        transform.position = targetPosition;
                    }
                    //Right
                    else if (absX < absY && swipeDirection.y < 0.0f && transform.position.z > -2.4f)
                    {
                        Vector3 targetPosition = transform.position + new Vector3(0, 0, moveDistance * -1);

                        // Move the GameObject to the target position.
                        transform.position = targetPosition;
                    }
                }
            }
        }
    }
}

