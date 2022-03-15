using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGamma : MonoBehaviour
{
    //Variables
    public float speed = 150f;
    public Rigidbody2D rb;
    public int duration = 10000;

    //Move object
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    //Lifetime
    private void Update()
    {
        duration -= 1;
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
    }

    //If collision with player, deal damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameObject.Find("Player") != null)
            {
                collision.gameObject.GetComponent<Player>().damage = true;
                
            }

        }
    }
}


