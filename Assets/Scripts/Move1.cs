using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoBehaviour
{
    public GameObject Pl;
    Rigidbody2D rb;
    string way="up";
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb!=null)
        {
            if (way == "up")
            {
                if (rb.transform.position.y < 3)
                {
                    rb.transform.position += Vector3.up * 2 * Time.deltaTime;
                }
                else
                {
                    way = "down";
                }
            }

            if (way == "down")
            {
                if (rb.transform.position.y > -3)
                {
                    rb.transform.position += Vector3.down * 2 * Time.deltaTime;
                }
                else
                {
                    way = "up";
                }
            }
            
        }
    }
}
