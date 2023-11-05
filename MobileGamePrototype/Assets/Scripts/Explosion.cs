using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public GameObject cubeMesh;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    private bool valid;
    // Use this for initialization
    void Start()
    {
        valid = true;
        // Calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        // Use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (valid)
        {
            if (collision.gameObject.CompareTag("Tile") || collision.gameObject.CompareTag("P1") || collision.gameObject.CompareTag("Coin"))
            {
                explode();
                if (collision.gameObject.CompareTag("P1"))
                {
                    collision.gameObject.GetComponent<Score>().lives--;
                }
                if (collision.gameObject.CompareTag("Coin"))
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }

    public void explode()
    {
        // Make object disappear
        //gameObject.SetActive(false);
        this.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        valid = false;
        // Loop 3 times to create 5x5x5 pieces in x, y, z coordinates
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        // Get explosion position
        Vector3 explosionPos = transform.position;
        // Get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        // Add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            // Get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    void createPiece(int x, int y, int z)
    {
        // Create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //piece = GameObject.Instantiate(cubeMesh);

        // Set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        
        // Add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
       // piece.AddComponent<CleanUp>();
        piece.gameObject.tag = "Obstacle";
        piece.transform.SetParent(this.transform);
    }
}