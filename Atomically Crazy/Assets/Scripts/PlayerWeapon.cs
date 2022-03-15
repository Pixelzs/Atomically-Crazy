using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    //GamePrefabs
    public Transform firepoint;
    public GameObject gammaPrefab;
    public GameObject chainprefab;
    //Variables
    public bool fire = true; // Was going to be used for cooldown to prevent player continually shooting

    //Check for Mouse input
    // Update is called once per frame
    void Update()
    {
        //Primary Fire
        if (Input.GetButtonDown("Fire1") && fire)
        {
            Shoot1();
        }
        //Secondary Fire
        if(Input.GetButtonDown("Fire2") && fire)
        {
            Shoot2();
        }
    }
    //Create Gamma
    void Shoot1()
    {
        Vector3 movement = new Vector3(firepoint.position.x, firepoint.position.y, 0);
        Instantiate(gammaPrefab, movement, firepoint.rotation);
    }
    //Create Chain Reaction
    void Shoot2()
    {
        Vector3 movement = new Vector3(firepoint.position.x, firepoint.position.y, 0);
        Instantiate(chainprefab, movement, firepoint.rotation);
    }
}
