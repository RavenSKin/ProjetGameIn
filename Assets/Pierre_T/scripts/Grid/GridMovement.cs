using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{   [Header("Valeur test")]

    public bool ObstacleHorizontal;
    public bool ObstacleVertical;
    [Header("Code sur")]
    public float Current_PM;
    public bool PlayerEndTurn;
    bool CanWalk;
    bool TargetGetted;
    bool SwitchToX;
    bool SwitchToY;

    int CollisionLayerMask;
    float DistanceX;
    float DistanceY;
    float speed = 3;
    float PM_Cost;
    float Max_PM = 3;
    float Treshold = 0.1f;
    
   
    Vector2 Cell_Position;
    Vector2 FirstPosition;
    Vector2 target;
    Vector2 CharacterPosition;
    Vector2 TopRay;
    Vector2 BotRay;
    Vector2 LeftRay;
    Vector2 RightRay;
    
    CellPosition _sc_Cell;
   
   
    private void Start()
    {
        InitializeVectors();
        CollisionLayerMask = 1<< 6;
        FirstPosition = new Vector2(0, 0);
        Current_PM = Max_PM;
    }
    void Update()
    {
        ShootRaycast();
       
        if (Current_PM < 0) // PM manager
        {
            Current_PM = 0;
        }
        SetCharacterPosition(); 
        GetTarget();
        if (TargetGetted && CanWalk) // deplacement du joueur
        {

            DistanceCalcul();
        }
      
        if(SwitchToX && SwitchToY && CharacterPosition == target)
        {
            
            SwitchToX = false;
            SwitchToY = false;
            TargetGetted = false;
        }
    }
   
   
    void SetCharacterPosition()
    {
       
      
        CharacterPosition = transform.position;
       

        
    }

    void DistanceCalcul()
    {

        DistanceX = Mathf.Abs(target.x - CharacterPosition.x);
        DistanceY = Mathf.Abs(target.y - CharacterPosition.y);        
        if (DistanceX > DistanceY)      // Si le joueur se situe loin a l'horizontal
        {
            SwitchToY = true;
            LookForYDirection();
            LookForXDirection();
        }
        if (DistanceX < DistanceY)
        {
            SwitchToX = true;
            LookForXDirection();
            LookForYDirection();
        }
        if(DistanceX == DistanceY)
        {
            SwitchToX = true;
            LookForXDirection();
            LookForYDirection();
        }
    }

    void LookForXDirection()
    {
        if (SwitchToX)
        {
            SwitchToY = false;
            if (target.x > CharacterPosition.x)
            {
                if (target.x != CharacterPosition.x)
                {
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                }
            }
            if (target.x < CharacterPosition.x)
            {
                if (target.x != CharacterPosition.x)
                {
                    transform.Translate(Vector2.left * speed * Time.deltaTime);
                }
            }
            if (DistanceX<Treshold && !SwitchToY)
            {
                transform.position = new Vector3(target.x, transform.position.y, 0);
                SwitchToX = false;
                SwitchToY = true;
            }
        }
    }
    void LookForYDirection()
    {
        if (SwitchToY)
        {
            SwitchToX = false;
            if (target.y > CharacterPosition.y)
            {
                if (target.y != CharacterPosition.y)
                {
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                }
            }
            if (target.y < CharacterPosition.y)
            {
                if (target.y != CharacterPosition.y)
                {
                    transform.Translate(Vector2.down * speed * Time.deltaTime);
                }
            }
            if (DistanceY<Treshold && !SwitchToX)
            {
                transform.position = new Vector3(transform.position.x, target.y, 0);
                SwitchToY = false;
                SwitchToX = true;
            }
        }
    }
    void GetTarget()
    {
 if (Input.GetMouseButtonDown(0))
        { 
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {

                _sc_Cell = hit.collider.gameObject.GetComponent<CellPosition>();
                Cell_Position = _sc_Cell.Cell_Pos;
                target = hit.collider.gameObject.transform.position;
                if(hit.collider.gameObject.GetComponent<CellPosition>().IsWalkable == true)
                {
                    CanWalk = true;
                     PM_Manager();
                }else CanWalk = false;
                TargetGetted = true;
               
               
            }
        } 
    }
    void PM_Manager()
    {
        Cell_Position.x = Mathf.Abs(Cell_Position.x);
       Cell_Position.y = Mathf.Abs(Cell_Position.y);

        PM_Cost = Mathf.Abs((Cell_Position.x - FirstPosition.x) + (Cell_Position.y - FirstPosition.y));
        Current_PM -= PM_Cost;
        
       
        
      
    }
    public void EndTurn()
    {
        PlayerEndTurn = true;

    }
    public void YourTurn()
    {
        PlayerEndTurn = false;
         Current_PM = Max_PM; 
       
      
        
    }
    void ShootRaycast()
    {
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, RightRay ,1 , CollisionLayerMask) ;
       
       
        RaycastHit2D hitleft  = Physics2D.Raycast(transform.position, LeftRay, 1, CollisionLayerMask);
        if (hitleft.collider != null || hitright.collider != null)
        {
            ObstacleHorizontal = true;
        }
        if(hitright.collider == null && hitleft.collider == null)
        {
            ObstacleHorizontal = false;
        }
       
        RaycastHit2D hitup = Physics2D.Raycast(transform.position, TopRay, 1, CollisionLayerMask);
        
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, BotRay, 1, CollisionLayerMask);
        if (hitdown.collider != null || hitup.collider != null)
        {
            ObstacleVertical = true;
        }
       if(hitdown.collider == null && hitup.collider == null)
        {
            ObstacleVertical = false;
        }
    }
    void InitializeVectors()
    {
        TopRay = Vector2.up;
        BotRay = Vector2.down;
        LeftRay = Vector2.left;
        RightRay = Vector2.right;
    }
   
}
