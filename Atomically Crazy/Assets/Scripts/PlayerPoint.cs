using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoint : MonoBehaviour
{
    //Get GameObjects
    public GameObject crosshairs;
    public GameObject player;
    private Vector3 target;

    //Hide Cursor
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    
    // Update is called once per frame
    void Update()
    {
        //Move crosshair along cursor
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        //Rotate Player to cursor
        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

    }
}
