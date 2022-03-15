using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    
    public bool hit;
    public bool death;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {

        if(hit)
        {
            FindClosetsEnemy();
            hit = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D Target)
    {
        if (Target.gameObject.tag == "Player")
        {
            if (GameObject.Find("Player") != null)
            {
                Debug.Log("Player");
                Target.gameObject.GetComponent<Player>().damage = true;
            }

        }

    }

    private void OnCollisionExit2D(Collision2D Target)
    {
        if (Target.gameObject.tag == "Player")
        {
            if (GameObject.Find("Player") != null)
            {
                Debug.Log("Player");
                Target.gameObject.GetComponent<Player>().damage = false;
                Target.gameObject.GetComponent<Player>().cooldown = 0;
            }
        }
    }

    public void FindClosetsEnemy()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            float distancetoclosetEnemyX = Mathf.Abs(10f);
            float distancetoclosetEnemyY = Mathf.Abs(10f);
            float distancetoclosetEnemy = Mathf.Abs(1000f);
          

            Enemy closestEnemy = null;
            Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

            
            foreach (Enemy currentEnemy in allEnemies)
            {

                if (currentEnemy.transform.position != this.transform.position)
                {
                    Debug.Log("Finding");
                    Debug.Log(this.transform.position.ToString());
                    Debug.Log(currentEnemy.transform.position.ToString());
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

            Debug.Log("Found");
            Debug.Log(distancetoclosetEnemyX.ToString());
           
            
            this.gameObject.GetComponent<Enemy>().enemyhealth = 0;
            closestEnemy.gameObject.GetComponent<Enemy>().enemyhealth = 0;
            hit = false;
        }


    }

}
