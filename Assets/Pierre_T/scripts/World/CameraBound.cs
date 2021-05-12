using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBound : MonoBehaviour
{
    float Xmovement;
    float YMovement;
    public Vector2 MinPos;
    public Vector2 MaxPos;
    public float Smoothing;
    public Transform Character;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < MaxPos.x && transform.position.y < MaxPos.y && transform.position.x >MinPos.x && transform.position.y > MinPos.y)
        {
            Xmovement = Mathf.Lerp(transform.position.x, Character.position.x, Smoothing);
            YMovement = Mathf.Lerp(transform.position.y, Character.position.y, Smoothing);
            transform.position = new Vector3(Xmovement, YMovement, transform.position.z);
           
        }
       if(transform.position.x > MaxPos.x )
        {
            transform.position = new Vector3(MaxPos.x, transform.position.y, transform.position.z);
        }
       
       if(transform.position.y > MaxPos.y)
        {
            transform.position = new Vector3(transform.position.x, MaxPos.y, transform.position.z);
        }
        
        if (transform.position.x < MinPos.x)
        {
            transform.position = new Vector3(MinPos.x, transform.position.y, transform.position.z);
        }
       
        if (transform.position.y < MinPos.y)
        {
            transform.position = new Vector3(transform.position.x, MinPos.y, transform.position.z);
        }
        
    }
    
}
