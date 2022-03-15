using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{

    //Creates a invisable wall around given area.
    public Camera MainCamera;

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, 40, 240);
        viewPos.y = Mathf.Clamp(viewPos.y, 40, 240);
        transform.position = viewPos;

    }
}
