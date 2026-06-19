using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    float speed = 5f;
    public Animator animator;
    public static bool IsRun;
    public GameObject camera;

    bool IsGrounded = false;
    float JumpHeight = 6f;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        camera.transform.position = new Vector3(player.transform.position.x + 4, player.transform.position.y, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb != null)
        {
            Move();
            animator.SetBool("IsRun", IsRun);
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            IsRun = true;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            IsRun = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (IsGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
            }
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
        if (collision.gameObject.CompareTag("Jumper"))
        {
            JumpHeight = 10f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
        if (collision.gameObject.CompareTag("Jumper"))
        {
            JumpHeight = 6f;
        }
    }
}
