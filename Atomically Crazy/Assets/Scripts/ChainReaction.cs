using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainReaction : MonoBehaviour
{
    //Variables
    public float speed = 150f;
    public Rigidbody2D rb;
    public int duration = 5000;
    //Move object
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    //Lifetime
    void Update()
    {
        duration -= 1;
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
    }
    //If collision with Enemy, activate chain reaction
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (GameObject.Find("Enemy") != null)
            {
                collision.gameObject.GetComponent<EnemyDamage>().destroy = true;
            }
            Destroy(gameObject);
        }
    }

}
