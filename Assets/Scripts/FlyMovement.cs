using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    public float speed = 3.5f; // Speed of the bug
    public float amplitude = 2f; // How wide the fly oscillates in the X direction
    public float frequency = 2f; // How fast the fly oscillates

    private float startX; // To store the initial X position
    private float timeElapsed; // Time tracking for sine wave movement
    private Rigidbody2D rb; // The bug's Rigidbody2D component
    private HealthController healthController; // Reference to the HealthController script

    // Start is called before the first frame update
    void Start()
    {
        // Set the fly's initial random X position at the top of the screen
        startX = Random.Range(-5f, 5f);
        transform.position = new Vector3(startX, 6f, 0f); // Y = 6 is off the top of the screen

        // Get the bug's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>(); 

        // Get the HealthController from the scene
        healthController = FindObjectOfType<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Time-based horizontal oscillation
        timeElapsed += Time.deltaTime;

        // Calculate the new X position using a sine wave
        float newX = startX + Mathf.Sin(timeElapsed * frequency) * amplitude;

        // Move the fly downward while also oscillating in the X direction
        transform.position = new Vector3(newX, transform.position.y - (speed * Time.deltaTime), 0f);

        // Destroy the fly if it has gone off-screen at the bottom
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    // OnTriggerEnter2D is called when the fly collides with the plant
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            // The fly has reached the plant, so update the health bar
            if (healthController != null)
            {
                healthController.RemoveHeart(); // Call method to remove 1 heart from the health bar
            }

            // Destroy the fly gameObject because it has reached the plant
            Destroy(gameObject);
        }
    }
}