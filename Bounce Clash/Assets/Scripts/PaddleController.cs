using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private string inputAxis;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Assign movement keys based on the paddle's tag
        if (gameObject.tag == "Player1")
            inputAxis = "VerticalP1";
        else if (gameObject.tag == "Player2")
            inputAxis = "VerticalP2";
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw(inputAxis);
        rb.linearVelocity = new Vector2(0, moveInput * speed);
    }
}
