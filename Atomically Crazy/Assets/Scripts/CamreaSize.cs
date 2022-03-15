using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamreaSize : MonoBehaviour
{
    public SpriteRenderer Size;
    // Start is called before the first frame update
    void Start()
    {
        float CamSize = Size.bounds.size.x * Screen.height / Screen.width * 0.5f;

        Camera.main.orthographicSize = CamSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
