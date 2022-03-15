using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    public float speed = 0.5f;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Player") != null)
        {
            offset = transform.position - player.transform.position;
        }
 
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameObject.Find("Player") != null)
        {
            Vector3 Target = player.transform.position + offset;
            Vector3 Transition = Vector3.Lerp(transform.position, Target, speed);
            transform.position = Transition;
        }
    }

}
