using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll : MonoBehaviour
{
    public static bool IsTrig = false;
    public GameObject JumpCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Bg"))
        {
            PlayerMove.IsGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Bg"))
        {
            PlayerMove.IsGrounded = true;
            PlayerMove.IsJumping = false;
        }
    }
}
