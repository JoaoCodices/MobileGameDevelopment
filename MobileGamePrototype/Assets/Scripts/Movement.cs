using System.Collections;
using System.Collections.Generic;
//using TreeEditor;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    //
    Vector3 up = Vector3.zero, right = new Vector3(0f, 90f, 0f), down = new Vector3(0f, 180f, 0f), left = new Vector3(0f, 270f, 0f), currentDirection = Vector3.zero;

    Vector3 nextPos, destination, direction;

    public float speed = 5f;

    bool canMove;
    float rayLength = 1.25f;

    //

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    //private bool isSwiping = false;
    public float moveDistance = 1.2f; // Adjust this value to change the distance the object moves.

    //

    private ShakeAnimation shake;

    void Start()
    {
        currentDirection = up;
        nextPos = Vector3.forward;
        destination = transform.position;

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<ShakeAnimation>();
    }
    void Update()
    {
        //Collision Check
        Ray myRay = new Ray(transform.position + new Vector3(0f, -0.35f, 0f), transform.forward);
        Ray myRay2 = new Ray(transform.position + new Vector3(0f, -0.35f, 0f), -transform.forward);
        Ray myRay3 = new Ray(transform.position + new Vector3(0f, -0.35f, 0f), transform.right);
        Ray myRay4 = new Ray(transform.position + new Vector3(0f, -0.35f, 0f), -transform.forward);
        RaycastHit hit;
        Debug.DrawRay(myRay.origin, myRay.direction, Color.green);
        Debug.DrawRay(myRay2.origin, myRay2.direction, Color.green);
        Debug.DrawRay(myRay3.origin, myRay3.direction, Color.green);
        Debug.DrawRay(myRay4.origin, myRay4.direction, Color.green);
        if (Physics.Raycast(myRay, out hit, rayLength))
        {
            if (hit.collider.tag == "Obstacle")
            {
                Debug.DrawRay(myRay.origin, myRay.direction, Color.red);
                
            }
        }
        if (Physics.Raycast(myRay2, out hit, rayLength))
        {
            if (hit.collider.tag == "Obstacle")
            {              
                Debug.DrawRay(myRay2.origin, myRay2.direction, Color.red);
            }
        }
        if (Physics.Raycast(myRay3, out hit, rayLength))
        {
            if (hit.collider.tag == "Obstacle")
            {
                Debug.DrawRay(myRay3.origin, myRay3.direction, Color.red);              
            }
        }
        if (Physics.Raycast(myRay4, out hit, rayLength))
        {
            if (hit.collider.tag == "Obstacle")
            {              
                Debug.DrawRay(myRay4.origin, myRay4.direction, Color.red);
            }
        }
        Move();
    }

    
    void Move()
    {
        //
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                if (currentSwipe.y < -0.5f)
                {              
                    if(currentSwipe.x < -0.5f && transform.position.x > -2.4f)
                    {
                        //Debug.Log("DOWN LEFT swipe");

                        nextPos = Vector3.left + new Vector3(-0.2f, 0f, 0f);
                        currentDirection = left;
                        canMove = true;
                    }
                    else if(currentSwipe.x > 0.5f && transform.position.z > -2.4f)
                    {                       
                        //Debug.Log("DOWN RIGHT swipe");

                        nextPos = Vector3.back + new Vector3(0f, 0f, -0.2f);
                        currentDirection = down;
                        canMove = true;
                    }
                }
                else if(currentSwipe.y > 0.5f)
                {                   
                    if (currentSwipe.x < -0.5f && transform.position.z < 2.4f)
                    {
                        //Debug.Log("UP LEFT swipe");

                        nextPos = Vector3.forward + new Vector3(0f, 0f, 0.2f);
                        currentDirection = up;
                        canMove = true;
                    }
                    else if (currentSwipe.x > 0.5f && transform.position.x < 2.4f)
                    {
                        //Debug.Log("UP RIGHT swipe");

                        nextPos = Vector3.right + new Vector3(0.2f, 0f, 0f);
                        currentDirection = right;
                        canMove = true;
                    }
                }
            }
        }



        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        //// Check for touch input.
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    // Detect the beginning of a swipe.
        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        touchStartPos = touch.position;
        //        isSwiping = true;
        //    }

        //    // Detect the end of a swipe.
        //    if (touch.phase == TouchPhase.Ended)
        //    {
        //        touchEndPos = touch.position;
        //        isSwiping = false;

        //        // Calculate the swipe direction vector.
        //        Vector2 swipeDirection = touchEndPos - touchStartPos;



        //        // Check if the swipe distance is greater than a threshold (to avoid accidental swipes).
        //        if (swipeDirection.magnitude >= 50.0f) // Adjust the threshold as needed.
        //        {
        //            float absX = Mathf.Abs(swipeDirection.x);
        //            float absY = Mathf.Abs(swipeDirection.y);
        //            Debug.Log(swipeDirection);
        //            //X-AXIS
        //            //Right
        //            if (absX > absY && swipeDirection.x > 0.0f && transform.position.z > -2.4f)
        //            {
        //                Debug.Log("S");
        //                nextPos = Vector3.back + new Vector3(0f, 0f, -0.2f);
        //                currentDirection = down;
        //                canMove = true;

        //            }
        //            //Left
        //            else if (absX > absY && swipeDirection.x < 0.0f && transform.position.z < 2.4f)
        //            {
        //                Debug.Log("W");
        //                nextPos = Vector3.forward + new Vector3(0f, 0f, 0.2f);
        //                currentDirection = up;
        //                canMove = true;
        //            }
        //            //Z-AXIS
        //            //Left
        //            if (absX < absY && swipeDirection.y > 0.0f && transform.position.x < 2.4f)
        //            {
        //                Debug.Log("D");
        //                nextPos = Vector3.right + new Vector3(0.2f, 0f, 0f);
        //                currentDirection = right;
        //                canMove = true;
        //            }
        //            //Right
        //            else if (absX < absY && swipeDirection.y < 0.0f && transform.position.x > -2.4f)
        //            {
        //                Debug.Log("A");
        //                nextPos = Vector3.left + new Vector3(-0.2f,0f,0f);
        //                currentDirection = left;
        //                canMove = true;
        //            }
        //        }
        //    }

        //    //if (Input.GetKeyDown(KeyCode.W))
        //    //{
        //    //    Debug.Log("W");
        //    //    nextPos = Vector3.forward;
        //    //    currentDirection = up;
        //    //}
        //    //if (Input.GetKeyDown(KeyCode.S))
        //    //{
        //    //    Debug.Log("S");
        //    //    nextPos = Vector3.back;
        //    //    currentDirection = down;
        //    //}
        //    //if (Input.GetKeyDown(KeyCode.D))
        //    //{
        //    //    Debug.Log("D");
        //    //    nextPos = Vector3.right;
        //    //    currentDirection = right;
        //    //}
        //    //if (Input.GetKeyDown(KeyCode.A))
        //    //{
        //    //    Debug.Log("A");
        //    //    nextPos = Vector3.left;
        //    //    currentDirection = left;
        //    //}


        if (Vector3.Distance(destination, transform.position) <= 0.00001f)
        {
            transform.localEulerAngles = currentDirection;
            if (canMove)
            {
                if (Valid())
                {
                    destination = transform.position + nextPos;
                    direction = nextPos;
                    canMove = false;
                }
                else
                {
                    shake.ShakeCam();
                    canMove = false;
                }
            }

        }
    }


    bool Valid()
    {
        Ray myRay = new Ray(transform.position + new Vector3(0f, -0.25f, 0f), transform.forward);
        RaycastHit hit;
        Debug.DrawRay(myRay.origin, myRay.direction, Color.red);

        if(Physics.Raycast(myRay, out hit, rayLength))
        {
            if(hit.collider.tag == "Obstacle")
            {               
                return false;
            }
        }
        return true;
    }
}

//public class Movement : MonoBehaviour
//{

//    private Vector2 touchStartPos;
//    private Vector2 touchEndPos;
//    private bool isSwiping = false;
//    public float moveDistance = 1.2f; // Adjust this value to change the distance the object moves.

//    private float lastTapTime;
//    public float jumpForce = 5.0f; // Adjust this value to control the jump force.
//    public float doubleTapInterval = 0.3f; // Adjust this value for your desired double-tap timing.

//    Rigidbody rb; // Assuming the player has a Rigidbody

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//    }
//    void Update()
//    {
//        // Check for double-tap input.
//        if (Input.touchCount == 1)
//        {
//            Touch touch = Input.GetTouch(0);

//            // Check if it's the second tap within the doubleTapInterval.
//            if (touch.phase == TouchPhase.Began && Time.time - lastTapTime < doubleTapInterval)
//            {
//                // Perform the jump action when a double tap is detected.
//                if (transform.position.y < 0.67f)
//                {
//                    Jump();
//                    Debug.Log("Double Tap");
//                }
//            }
//            else
//            {
//                lastTapTime = Time.time;
//            }
//        }
//        void Jump()
//        {
//            // Ensure the Rigidbody2D component exists.
//            if (rb != null)
//            {
//                // Apply an upward force to make the player jump.
//                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
//            }
//        }

//        // Check for touch input.
//        if (Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);

//            // Detect the beginning of a swipe.
//            if (touch.phase == TouchPhase.Began)
//            {
//                touchStartPos = touch.position;
//                isSwiping = true;
//            }

//            // Detect the end of a swipe.
//            if (touch.phase == TouchPhase.Ended)
//            {
//                touchEndPos = touch.position;
//                isSwiping = false;

//                // Calculate the swipe direction vector.
//                Vector2 swipeDirection = touchEndPos - touchStartPos;



//                // Check if the swipe distance is greater than a threshold (to avoid accidental swipes).
//                if (swipeDirection.magnitude >= 50.0f) // Adjust the threshold as needed.
//                {
//                    float absX = Mathf.Abs(swipeDirection.x);
//                    float absY = Mathf.Abs(swipeDirection.y);
//                    Debug.Log(swipeDirection);
//                    //X-AXIS
//                    //Right
//                    if (absX > absY && swipeDirection.x > 0.0f && transform.position.x < 2.4f)
//                    {
//                        Vector3 targetPosition = transform.position + new Vector3(moveDistance, 0, 0);

//                        // Move the GameObject to the target position.
//                        transform.position = targetPosition;
//                    }
//                    //Left
//                    else if (absX > absY && swipeDirection.x < 0.0f && transform.position.x > -2.4f)
//                    {
//                        Vector3 targetPosition = transform.position + new Vector3(moveDistance * -1, 0, 0);

//                        // Move the GameObject to the target position.
//                        transform.position = targetPosition;
//                    }
//                    //Z-AXIS
//                    //Left
//                    if (absX < absY && swipeDirection.y > 0.0f && transform.position.z < 2.4f)
//                    {
//                        Vector3 targetPosition = transform.position + new Vector3(0, 0, moveDistance);

//                        // Move the GameObject to the target position.

//                        transform.position = targetPosition;
//                    }
//                    //Right
//                    else if (absX < absY && swipeDirection.y < 0.0f && transform.position.z > -2.4f)
//                    {
//                        Vector3 targetPosition = transform.position + new Vector3(0, 0, moveDistance * -1);

//                        // Move the GameObject to the target position.
//                        transform.position = targetPosition;
//                    }
//                }
//            }
//        }
//    }
//}

