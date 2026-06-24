using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb, rb_c, rb_jump;
    float speed = 5f;
    public Animator animator;
    public static bool IsRun;
    public GameObject Mcamera;
    public static int Score = 0;
    public TextMeshProUGUI txt;
    AudioSource coin_zvuk;
    public Canvas canv;
    int a = 2;

    public static bool IsGrounded = false, IsJumping = false;
    float JumpHeight = 6f;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        rb_c = Mcamera.GetComponent<Rigidbody2D>();
        Mcamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        coin_zvuk = player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb != null)
        {
            Move();
            animator.SetBool("IsRun", IsRun);
            animator.SetBool("IsGrounded", IsGrounded);
            animator.SetBool("IsJumping", IsJumping);
        }

        txt.text = Score.ToString() + "/11 coins";
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
            rb.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
            canv.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.position += Vector3.left * speed * Time.deltaTime;
            rb.transform.localScale = new Vector3(-0.25f, 0.25f, 1f);
            canv.transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (a > 0)
            {
                rb.transform.position += new Vector3(0, 3, 0);
                a -= 1;
                Debug.Log(a);
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (IsGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
                IsJumping = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsJumping = false;
        }
        

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Jumper"))
        {
            JumpHeight = 6f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Jumper"))
        {
            JumpHeight = 10f;
        }
        if (collision.gameObject.CompareTag("Lava"))
        {
            rb.transform.position = new Vector3(-4,-3,0);
            a = 2;
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            Score++;
            coin_zvuk.Play();
        }

        if (collision.gameObject.CompareTag("Exit"))
        {
            if (Score >= 11)
            {
                SceneManager.LoadScene(1);
            }
            
        }

    }
}
