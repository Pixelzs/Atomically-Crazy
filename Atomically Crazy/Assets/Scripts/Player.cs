using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    //Delcare Variables
    public Vector2 speed = new Vector2(120, 120);

    public int playerHealth = 100;
    public bool damage = false;
    public bool gas = false;
    public bool solid = false;
    public bool plasma = false;
    public bool liquid = false;
    private bool once = false;
    public int cooldown = 0;
    public int duration = 0;
    public GameObject weapon;
    
    //Sprite
    public SpriteRenderer spriteRenderer;
    public Sprite Solid;
    public Sprite Liquid;
    public Sprite Gas;
    public Sprite Plasma;
    public Sprite Normal;

    

    //UI
    public HealthBar healthbarScript;
    public UIScripts UIScriptRef;

    // // // // // // // // 

    //Step//
    // Update is called once per frame
    void Update()
    {
        //Health
        if (playerHealth <= 0)
        {
            UIScriptRef.DeathMenuActivate();
        }
        else
        {
            //Movement
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");


            //States
            if (gas)
            {
                spriteRenderer.sprite = Gas;
                speed = new Vector2(300, 300);
                duration = 1000;
                gas = false;
                once = true;
                weapon.gameObject.GetComponent<PlayerWeapon>().fire = false;
            }
            if (solid)
            {
                spriteRenderer.sprite = Solid;
                speed = new Vector2(30, 30);
                playerHealth = playerHealth * 2;
                healthbarScript.SetMaxHealth(playerHealth);
                healthbarScript.SetHealth(playerHealth);
                UIScriptRef.GetComponent<UIScripts>().currentHealth = playerHealth;
                duration = 2000;
                solid = false;
                once = true;
                //damage
            }
            if (liquid)
            {
                spriteRenderer.sprite = Liquid;
                playerHealth += 50;
                duration = 1000;
                liquid = false;
                once = true;
                //gamma speed
                if (GameObject.Find("Primary") != null)
                {
                    weapon.gameObject.GetComponent<PlayerWeapon>().gammaPrefab.gameObject.GetComponent<Gamma>().speed = 300f;
                }
            }
            if (plasma && once == false)
            {
                speed = new Vector2(120, 120);
                playerHealth = playerHealth * 10;
                healthbarScript.SetMaxHealth(playerHealth);
                healthbarScript.SetHealth(playerHealth);
                duration = 1000;
                once = true;
                //damage
            }
    

            //Duration of state
            if (duration > 0)
            {
                duration -= 1;
            }
            else if(duration<=0 && once)
            {
                //Revert back to normal
                speed = new Vector2(120, 120);
                playerHealth = 100;
                healthbarScript.SetMaxHealth(playerHealth);
                healthbarScript.SetHealth(playerHealth);
                UIScriptRef.GetComponent<UIScripts>().currentHealth = playerHealth;
                weapon.gameObject.GetComponent<PlayerWeapon>().fire = true;
                weapon.gameObject.GetComponent<PlayerWeapon>().gammaPrefab.gameObject.GetComponent<Gamma>().speed = 150f;
                once = false;
                spriteRenderer.sprite = Normal;
            }
            
            //Confirm movement direction
            Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
            movement *= Time.deltaTime;
            transform.Translate(movement);

            //Player Hurt
            if (damage && gas!=true)
            {
                PlayerHurt();
            }          
        }

    }


    //Player collision
    private void OnCollisionEnter2D(Collision2D Target)
    {
        //Gas Bottle
        if (Target.gameObject.tag == "Gas")
        {
            if (GameObject.Find("Gas") != null)
            {
                gas = true;
                Destroy(Target.gameObject);
            }

        }

        //Liquid Bottle
        if (Target.gameObject.tag == "Liquid")
        {
            if (GameObject.Find("Liquid") != null)
            {
                liquid = true;
                Destroy(Target.gameObject);
            }

        }

        //Soild Bottle
        if (Target.gameObject.tag == "Solid")
        {
            if (GameObject.Find("Solid") != null)
            {
                solid = true;
                Destroy(Target.gameObject);
            }

        }
    }

    void PlayerHurt() 
    {
        //Remove health
        UIScriptRef.TakeDamage(10);
        damage = false;
    }
}
