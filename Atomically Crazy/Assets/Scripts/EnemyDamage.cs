using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //Variables
    public bool destroy = false;
    public bool death;



    private void Update()
    {
        //Check if destory is true
        switch (destroy)
        {
            case true:

                FindClosetsEnemy();
                destroy = false;
                break; //Force Prevent Update to continually loop.
        }

    }

    //Enemy Collision
    private void OnCollisionEnter2D(Collision2D Target)
    {
        //Damage player if collision
        if (Target.gameObject.tag == "Player")
        {
            if (GameObject.Find("Player") != null)
            {
                Target.gameObject.GetComponent<Player>().damage = true;
                this.gameObject.GetComponent<Enemy>().enemyhealth = 0;
            }

        }

        //Destroy other enemy if collision
        if (Target.gameObject.tag == "Enemy")
        {
            if (GameObject.Find("Enemy") != null)
            {
                Target.gameObject.GetComponent<Enemy>().enemyhealth = 0;
                this.gameObject.GetComponent<Enemy>().enemyhealth = 0;
            }

        }

    }

    //Force prevent player's health decreasing
    private void OnCollisionExit2D(Collision2D Target)
    {
        if (Target.gameObject.tag == "Player")
        {
            if (GameObject.Find("Player") != null)
            {
                Target.gameObject.GetComponent<Player>().damage = false;
                Target.gameObject.GetComponent<Player>().cooldown = 0;
            }
        }
    }

    //Find Closet Enemy-Chain Reaction
    public void FindClosetsEnemy()
    {
        //Find any Enemy Object
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            //Declare distance thats infinte value
            float distancetoclosetEnemyX = Mathf.Infinity;
            float distancetoclosetEnemyY = Mathf.Infinity;
            float distancetoclosetEnemy = Mathf.Infinity;

            //Create array to get all enemies and variable to house the closet value
            Enemy closestEnemy = null;
            Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

            //Find Loop
            foreach (Enemy currentEnemy in allEnemies)
            {
                //Check all enemies then compare recent to current, if smaller then set that as smallest. Ignore first enemy(since that is itself)
                if (currentEnemy.transform.position != this.transform.position)
                {

                    float distanceToEnemyX = (currentEnemy.transform.position.x - this.transform.position.x);
                    float distanceToEnemyY = (currentEnemy.transform.position.y - this.transform.position.y);
                    float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                    if (distanceToEnemy < distancetoclosetEnemy)
                    {
                        distancetoclosetEnemyX = distanceToEnemyX;
                        distancetoclosetEnemyY = distanceToEnemyY;
                        distancetoclosetEnemy = distanceToEnemy;
                        closestEnemy = currentEnemy;
                    }

                }

            }

            //Half the closest distance
            float halfx = distancetoclosetEnemyX / 2;
            float halfy = distancetoclosetEnemyY / 2;

            //Move both enemies to the half distance
            this.transform.position += new Vector3(halfx, halfy, 0);
            closestEnemy.transform.position -= new Vector3(halfx, halfy, 0);

            //Destory Enemy
            destroy = false;
        }

    }

}
