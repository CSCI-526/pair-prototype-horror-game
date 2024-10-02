using UnityEngine;

public class RandomBouncingMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    private Vector3 moveDirection;

    void Start()
    {
        // Initialize a random direction for movement
        GetRandomDirection();
    }

    void Update()
    {
        // Move the object
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void GetRandomDirection()
    {
        // Generate a random direction on the x and z axes
        float randomAngle = Random.Range(0f, 360f);
        moveDirection = new Vector3(Mathf.Cos(randomAngle), 0, Mathf.Sin(randomAngle)).normalized;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object collided with a wall
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ghost"))
        {
            // Reflect the direction based on the normal of the collision
            moveDirection = Vector3.Reflect(moveDirection, collision.contacts[0].normal);
        }
    }
}