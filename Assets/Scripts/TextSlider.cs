using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextSlider : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float hiddenYOffset = -2.0f; // Offset to ensure it's hidden below the screen
    public Vector3 initialPosition;
    public BoxCollider2D triggerHitbox;
    private RectTransform rectTransform;


    private bool isMoving = false;

    void Start()
    {
        //Time.timeScale = 3f;
        // Save the initial position
        initialPosition = transform.position;

        // Move the text to the hidden position
        transform.position = new Vector3(initialPosition.x, -8, initialPosition.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            // Move towards the initial position smoothly
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);

            // Check if the object has reached the initial position
            if (transform.position == initialPosition)
            {
                // Stop moving
                isMoving = false;
            }
        }
    }
}
