using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollide : MonoBehaviour
{
    public GameObject coin;
    AudioSource zvuk;

    private void Start()
    {
        zvuk = coin.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("coin");
            PlayerMove.Score++;
            zvuk.Play();
        }
    }
}

