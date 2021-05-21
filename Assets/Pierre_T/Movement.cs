using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public  Animator chara_Anim;
    public  Rigidbody2D rb2D;
    public  float moveSpeed ;
    public  bool IsMovingHorizontal;
    public  bool IsMovingVertical;
    public  bool IsMoving;
           
    float moveX;
    float moveY;
    Vector2 CharacterPos;
 
    // Update is called once per frame
    void Update()
    {
        chara_Anim.SetFloat("X", moveX);
        chara_Anim.SetFloat("Y", moveY);
        moveX = 0f;
        moveY = 0f;
        IdleSelector();
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
                chara_Anim.SetBool("IsWalking", true);
                IsMovingVertical = true;
                IsMovingHorizontal = false;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveY = -1;
                chara_Anim.SetBool("IsWalking", true);
                IsMovingVertical = true;
                IsMovingHorizontal = false;
            }
        }
         if (!IsMovingVertical)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                moveX = -1;
                chara_Anim.SetBool("IsWalking", true);
                IsMovingHorizontal = true;
                IsMovingVertical = false;
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveX = 1;
                chara_Anim.SetBool("IsWalking", true);
                IsMovingHorizontal = true;
                IsMovingVertical = false;
            }
        }
        CharacterPos = new Vector2(moveX, moveY).normalized;
        rb2D.velocity = CharacterPos*moveSpeed;
    }

   
    void IdleSelector()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            chara_Anim.SetBool("IsWalking", false);
            chara_Anim.SetFloat("LastX", 0);
            chara_Anim.SetFloat("LastY", 1);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            chara_Anim.SetBool("IsWalking", false);
            chara_Anim.SetFloat("LastX", -1);
            chara_Anim.SetFloat("LastY", 0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            chara_Anim.SetBool("IsWalking", false);
            chara_Anim.SetFloat("LastX", 0);
            chara_Anim.SetFloat("LastY", -1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            chara_Anim.SetBool("IsWalking", false);
            chara_Anim.SetFloat("LastX", 1);
            chara_Anim.SetFloat("LastY", 0);
        }
    }
    
}
