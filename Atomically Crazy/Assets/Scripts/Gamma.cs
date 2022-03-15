using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamma : MonoBehaviour
{
    //Variables
    public float speed = 150f;
    public Rigidbody2D rb;
    public int duration = 10000;

    private GameObject PlayerUI;

    //Move object and Find Player
    void Start()
    {
        PlayerUI = GameObject.Find("Player");
        rb.velocity = transform.right * speed;
    }
    //Lifetime
    private void Update()
    {
        duration -= 1;
        if(duration<=0)
        {
            Destroy(gameObject);
        }
    }
    //If collision with Enemy, deal damage and Increase player's ultimate Plasma
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Enemy>().enemyhealth = -1;
            PlayerUI.gameObject.GetComponent<Player>().UIScriptRef.GainPlasma(5);
        }
    }
}


