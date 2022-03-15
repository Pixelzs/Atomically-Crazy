using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Get Gameobjects
    public GameObject Death;
    public GameObject enemyPrefab;
    private GameObject waypoint;
    private Vector3 wayPointPos;

    //Variables
    public int enemyhealth = 30;
    private float speed = 100f;
    public int duration = 0;

    //Get Player
    void Start()
    {
        waypoint = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Health
        if (enemyhealth <= 0)
        {
            //Create a instance, that is a spark
            Instantiate(Death, transform.position, transform.rotation);
            Destroy(gameObject);//End
        }
        else
        {
            //Rotation and Movement, both looking towards and moving towards player
            wayPointPos = new Vector3(waypoint.transform.position.x, waypoint.transform.position.y, 0);
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
            Vector3 dir = waypoint.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //Cooldown before shooting
            if (duration > 0)
            {
                duration -= 1;
            }
            else if (duration <= 0)
            {
                Shoot();
            }


        }
    }

    //Enemy shooting
    void Shoot()
    {
        Vector3 movement = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        Instantiate(enemyPrefab, movement, this.transform.rotation);
        duration = 1000;//Cooldown
    }



}
