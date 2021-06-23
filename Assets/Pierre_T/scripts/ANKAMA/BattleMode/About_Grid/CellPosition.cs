using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPosition : MonoBehaviour
{
    [Header("Debug Info")]
  
      public bool IsWalkable;
      public bool OutOfBound;
      public bool OutOfPM;
      public bool LinkedOutOfSight;
      public bool OutOfSight;
      public bool UpperLinked;
      public bool EnemyCase;
      public bool _outsightLinked;
     
      public float MP_Current;
      public float CellMP;

      public Vector2 Cell_Pos;

      Vector2 Cell_WorldPos;
      public List<GameObject> LinkedCell = new List<GameObject>();
   

       [Header("Info caché ")]
      int IndexCheck;
      
      float boundsLeft = -3;
      float boundsRight = 12;
      float boundsUp = 0;
      float boundsDown = -7f;
      Vector2 PlayerPos =  new Vector2(0, 0);
      Vector3 TouchedObstacles;
      Player_Manager PlayerMovement;
      Transform Player;
      BoxCollider2D _box;
      SpriteRenderer _sprite;
      Color _standardColor;
      Color _alphacolor ;
    private void Start()
    {  
     
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _box = gameObject.GetComponent<BoxCollider2D>();
        _alphacolor.a = 0;
        _standardColor = _sprite.color;
    }
    // Update is called once per frame
    void Update()
    {
        
     
      
      if(LinkedCell.Count> 0 )
      {
          Linked();
      } 
      if(LinkedCell.Count == 0)
      {
          NotLinked();
      }
     
      
       
            
    }
    void Initiate()
    {
        PlayerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Manager>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void OnBound()
    {
        Cell_WorldPos = new Vector2(Mathf.Round(transform.position.x) , Mathf.Round(transform.position.y));
        if (Cell_WorldPos.x < boundsLeft || Cell_WorldPos.x > boundsRight || Cell_WorldPos.y < boundsDown || Cell_WorldPos.y > boundsUp)
        {
            OutOfBound = true;
        }
        else OutOfBound = false;
    }
    void Out_PM()
    {
        // Position de la cellule 
        Cell_Pos.x = Mathf.Abs(Cell_Pos.x);
        Cell_Pos.y = Mathf.Abs(Cell_Pos.y);
        // Calcul de la distance entre le joueur et la cellule 
        CellMP = Mathf.Abs((Cell_Pos.x - PlayerPos.x) + (Cell_Pos.y - PlayerPos.y));
        
            if (CellMP <= MP_Current)
            {
                IsWalkable = true;
                OutOfPM = false;
            }
            else OutOfPM = true; IsWalkable = false;       
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        OutOfSight = true;
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
         OutOfSight = false;
        
       
    }
   
    void Linked()
    {

      
            Initiate();
            
            MP_Current = PlayerMovement.Current_PM;
            Out_PM();
            OnBound();
            if(!IsWalkable)
            {
                foreach(GameObject cell in LinkedCell)
                {
                    cell.GetComponent<CellPosition>().LinkedOutOfSight = true;
                }
            }
            if(OutOfPM || OutOfSight || OutOfBound|| LinkedOutOfSight || UpperLinked || EnemyCase )
            {
                 _sprite.color = _alphacolor;
                  IsWalkable = false;
                
            }  
            if(!OutOfPM && !OutOfSight && !OutOfBound && !LinkedOutOfSight && !UpperLinked && !EnemyCase )
            {
                _sprite.color = _standardColor;
                IsWalkable = true;
            }
            if(OutOfSight)
            {
                foreach(GameObject cell in LinkedCell)
                {
                    cell.GetComponent<CellPosition>().LinkedOutOfSight = true;
                }
            }else{
                foreach(GameObject cell in LinkedCell)
                {
                    cell.GetComponent<CellPosition>().LinkedOutOfSight = false;
                }
                     }
      
    }

    void NotLinked()
    {
 
      
        Initiate();
        MP_Current = PlayerMovement.Current_PM;
            Out_PM();
           OnBound();
            if(OutOfPM || OutOfSight || OutOfBound||LinkedOutOfSight||UpperLinked||EnemyCase)
            {
                 _sprite.color = _alphacolor;
                  IsWalkable = false;
                
            }  
            if(!OutOfPM && !OutOfSight && !OutOfBound&&!LinkedOutOfSight&& !UpperLinked && !EnemyCase )
            {
                _sprite.color = _standardColor;
                IsWalkable = true;
            }
   
    }
    public void UpperLinkedOn() 
    {
        UpperLinked = true;
    }   
    public void UpperLinkedOff()
    {
        UpperLinked = false;
    }
    public void ResetLink()
    {
        UpperLinked = false;
    }
}
