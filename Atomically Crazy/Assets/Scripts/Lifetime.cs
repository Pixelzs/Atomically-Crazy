using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{

    //Lifetime for Spark from enemy death, particles wasn't used since I wasn't aware how to use it so this felt quicker.

    float timer = 0;
    bool timerReached = false;

    void Update()
    {
        if (!timerReached)
            timer += Time.deltaTime;

        if (!timerReached && timer > 1)
        {
            Destroy(gameObject);
            timerReached = true;
        }
    }
}
