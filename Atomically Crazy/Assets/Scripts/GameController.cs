using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Gather Objects to spawn in map
    public GameObject Enemies;
    public GameObject Eve;
    public GameObject Gas;
    public GameObject Liquid;
    public GameObject Solid;

    //Declare Variables
    public bool reset;
    public int score;
    public int enemies = 1;
    float timer = 0;
    bool timerReached = false;


    // Update is called once per frame
    void Update()
    {
        //increase timer
        if (!timerReached)
            timer += Time.deltaTime;

        //if timer reaches a number between 5 and 10
        if (!timerReached && timer > Random.Range(5,10))
        {
            int rnd = Random.Range(1, 3);
            //Spawn Random ability
            switch (rnd)
            {
                case 3:
                    GameObject Objc3 = Instantiate(Gas, new Vector3(Random.Range(50, 240), Random.Range(50, 240), 0), Quaternion.identity);
                    Objc3.name = Objc3.name.Replace("(Clone)", "");
                    break;
                case 2:
                    GameObject Objc2 = Instantiate(Liquid, new Vector3(Random.Range(50, 240), Random.Range(50, 240), 0), Quaternion.identity);
                    Objc2.name = Objc2.name.Replace("(Clone)", "");
                    break;
                case 1:
                    GameObject Objc = Instantiate(Solid, new Vector3(Random.Range(50, 240), Random.Range(50, 240), 0), Quaternion.identity);
                    Objc.name = Objc.name.Replace("(Clone)", "");
                    break;

            }
            timerReached = true;//Stop spawning
        }
        if (timerReached)
        {
            //Continue increasing and reset timer to spawn ability again
            timer += Time.deltaTime;
            if(timer > Random.Range(15,20))
            {
                timer = 0;
                timerReached = false;
            }
        }

        //Game Rest
        if (reset)
        {
            //Reset Timer
            timer = 0;
            timerReached = false;

            //Spawn Enemies
            if (enemies < 7)
            {
                enemies += Random.Range(1, 2);
            }
            for (int i = 0; i < enemies; i++)
            {
                //Spawn enemy in random position in area.
                GameObject ObjcE = Instantiate(Enemies, new Vector3(Random.Range(24, 255), Random.Range(24, 255), 0), Quaternion.identity);
                ObjcE.name = ObjcE.name.Replace("(Clone)", "");
            }
            //Create Eve in random position in area
            Instantiate(Eve, new Vector3(Random.Range(50, 240), Random.Range(50, 240), 0), Quaternion.identity);
            reset = false;
            //Reset Complete
        }
    }
}
