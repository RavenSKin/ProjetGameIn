using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBound : MonoBehaviour
{
    public float LeftBound;
    public float RightBound;
    public float UpBound;
    public float DownBound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < LeftBound)
        {
            transform.position = new Vector3(LeftBound, transform.position.y, transform.position.z);
        }
        if(transform.position.x > RightBound)
        {
            transform.position = new Vector3(RightBound, transform.position.y, transform.position.z);
        }
        if(transform.position.y > UpBound)
        {
            transform.position = new Vector3(transform.position.x, UpBound, transform.position.z);
        }
        if(transform.position.y < DownBound)
        {
            transform.position = new Vector3(transform.position.x, DownBound, transform.position.z);
        }
    }
}
