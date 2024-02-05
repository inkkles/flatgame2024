using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 2.0f; // Adjust the speed of cloud movement

    private SpriteRenderer spriteRenderer;
    private Camera mainCamera;
    private float spriteWidth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main;

        // Calculate the width of the sprite
        spriteWidth = spriteRenderer.bounds.size.x;
    }

    void Update()
    {
        MoveCloud();
    }

    void MoveCloud()
    {
        // Move the cloud to the right
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Calculate the position where the left edge of the sprite will be out of view
        float minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - spriteWidth / 2;

        // Check if the left edge of the sprite is out of view
        if (transform.position.x - spriteWidth / 2 > mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x)
        {
            // Teleport the cloud to the left
            Vector3 newPosition = new Vector3(minX, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
