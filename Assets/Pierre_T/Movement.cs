using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 CharacterPos;
    
    public Rigidbody2D rb2D;
    public float moveSpeed ;
    public Transform MovePoint;
    public LayerMask Object;
    public float moveDistance;
  public  bool IsMovingHorizontal;
    public  bool IsMovingVertical;
    bool StopMoving;
   public bool IsMoving;
    public Vector3 LastMovement;
    float moveX;
    float moveY;
 
    // Update is called once per frame
    void Update()
    {
        moveX = 0f;
        moveY = 0f;
        if(moveX==0f||moveY == 0f)
        {
            IsMoving = false;
        }
      
        if (!IsMoving)
        {
            IsMovingVertical = false;
            IsMovingHorizontal = false;
        }
        if (!IsMovingHorizontal)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                moveY = 1;
                IsMovingVertical = true;
                IsMovingHorizontal = false;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveY = -1;
                IsMovingVertical = true;
                IsMovingHorizontal = false;
            }
        }
         if (!IsMovingVertical)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                moveX = -1;
                IsMovingHorizontal = true;
                IsMovingVertical = false;
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveX = 1;
                IsMovingHorizontal = true;
                IsMovingVertical = false;
            }
        }
        CharacterPos = new Vector2(moveX, moveY).normalized;
        rb2D.velocity = CharacterPos*moveSpeed;
    }

   
 
    
}
