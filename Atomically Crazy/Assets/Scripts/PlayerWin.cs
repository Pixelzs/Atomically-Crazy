using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    //Declare gameobjects
    private GameObject GameController;
    private GameObject Score;

    //Check for Collision with Player
    private void OnCollisionEnter2D(Collision2D Target)
    {

        if (Target.gameObject.tag == "Player")
        {
            //Ensure Player does exist
            if (GameObject.Find("Player") != null)
            {
                //Locate other GameObjects
                GameController = GameObject.Find("GameController");
                Score = GameObject.Find("EventSystem");

                //Reset map and increase player score
                GameController.gameObject.GetComponent<GameController>().score += 100;
                GameController.gameObject.GetComponent<GameController>().reset = true;
                Score.gameObject.GetComponent<UIScripts>().IncreaseScore();

                //Destory Eve
                Destroy(gameObject);
            }

        }
    }
}
