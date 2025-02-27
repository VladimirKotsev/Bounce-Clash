using System;
using UnityEngine;


public class BallController : MonoBehaviour
{
    public int result = 0;
    DateTime startTime;
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        startTime = DateTime.Now;
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        float xDirection = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        float yDirection = UnityEngine.Random.Range(-1f, 1f);
        Vector2 direction = new Vector2(xDirection, yDirection).normalized;

        rb.linearVelocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Final score: " + result);
        }

        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            result++;
            Vector2 ballPosition = transform.position;
            Vector2 paddlePosition = collision.transform.position;
            float paddleHeight = collision.collider.bounds.size.y;

            float hitFactor = (ballPosition.y - paddlePosition.y) / paddleHeight;
            float newAngle = hitFactor * 75f; 

            // Bounce ball in the opposite horizontal direction
            Vector2 newDirection = new Vector2(-Mathf.Sign(rb.linearVelocity.x), Mathf.Sin(newAngle * Mathf.Deg2Rad)).normalized;
            rb.linearVelocity = newDirection * speed;
        }
    }

    void Update()
    {
        TimeSpan elapsedTime = DateTime.Now - startTime;
        if ((double)elapsedTime.TotalSeconds == 30.5)
            speed++;
    }
}
