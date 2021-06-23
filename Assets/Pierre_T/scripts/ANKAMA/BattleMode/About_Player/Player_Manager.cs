using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Manager : MonoBehaviour
{
    // LastX/Y = Idle
    // X/Y = Walking

    [Header("Valeur test")]

    public Animator _damage;
    public TextMeshProUGUI PA_Displayer;
    public TextMeshProUGUI PM_Displayer;
    LayerMask Layertiles;
    float xValue;
    float yValue;
    public int Max_PA;
   public int Current_PA;
    public GameObject enemy;
    GameObject tile;
    Vector3 enemy_Position;
    public Animator chara_Anim;
   public int DamageToDeal;
    [Header("Code sur")]
    bool invertMovePattern;
    public List<Vector2> Corner = new List<Vector2>();
    [HideInInspector]public bool IsCorner;
    [HideInInspector] public bool ObstacleHorizontal;
    [HideInInspector] public bool ObstacleVertical;
    [HideInInspector] public float Current_PM;
    [HideInInspector] public bool PlayerEndTurn;
    bool CanWalk;
    bool TargetGetted;
    bool SwitchToX;
    bool SwitchToY;
    public GameObject TileTopRay;
    public GameObject TileBotRay;
    public GameObject TileLeftRay;
    public GameObject TileRightRay;
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
    [HideInInspector] public Vector2 CharacterPosition;
    Vector2 TopRay;
    Vector2 BotRay;
    Vector2 LeftRay;
    Vector2 RightRay;
    
    CellPosition _sc_Cell;
   
   
    private void Start()
    {
        
        InitializeVectors();
        Layertiles = 1 << 3;
        CollisionLayerMask = 1<< 6;
        FirstPosition = new Vector2(0, 0);
        Current_PM = Max_PM;
        Current_PA = Max_PA;
        
    }
    void Update()
    {
        
        
        PA_Displayer.text = Current_PA +"";
        PM_Displayer.text = Current_PM + "";
        chara_Anim.SetFloat("LastX", xValue);
        chara_Anim.SetFloat("LastY", yValue);
        chara_Anim.SetFloat("X", xValue);
        chara_Anim.SetFloat("Y", yValue);
        FindEnemy();
        ShootRaycast();
        CheckPlayerPosition();
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
       
          
     
            if(CharacterPosition == target)
        {
            chara_Anim.SetBool("IsWalking", false);
         

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
        if (!ObstacleHorizontal && !ObstacleVertical && !IsCorner)
        {
            if (DistanceX > DistanceY)      // Si la target se situe loin a l'horizontal
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
            if (DistanceX == DistanceY)
            {
                SwitchToX = true;
                LookForXDirection();
                LookForYDirection();
            }
        }
        if (IsCorner)
        {
            SwitchToY = true;
            LookForYDirection();
            LookForXDirection();
        }

        if (ObstacleHorizontal && !ObstacleVertical && !IsCorner)
        {
            SwitchToY = true;
            LookForYDirection();
            LookForXDirection();
        }
        if (ObstacleVertical && !ObstacleHorizontal &&!IsCorner)
        {
            SwitchToX = true;
            LookForXDirection();
            LookForYDirection();
        }
        if(ObstacleVertical && ObstacleHorizontal && !IsCorner)
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
                    chara_Anim.SetBool("IsWalking", true);
                    
                    yValue = 0;
                    xValue = 1;
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                }
            }
            if (target.x < CharacterPosition.x)
            {
                if (target.x != CharacterPosition.x)
                {
                    transform.Translate(Vector2.left * speed * Time.deltaTime);
                    chara_Anim.SetBool("IsWalking", true);
                   
                    yValue = 0;
                    xValue = -1;
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
                    chara_Anim.SetBool("IsWalking", true);
                
                    xValue = 0;
                    yValue = 1;
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                }
            }
            if (target.y < CharacterPosition.y)
            {
                if (target.y != CharacterPosition.y)
                {
                    chara_Anim.SetBool("IsWalking", true);
                   
                    xValue = 0;
                    yValue = -1;
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
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero , 1<<3);
            Physics2D.IgnoreLayerCollision(3, 6);
            if (hit.collider != null)
            {
                
                if(gameObject.GetComponent<Show_Pattern>().MovePattern.activeInHierarchy == true)
                {
                _sc_Cell = hit.collider.gameObject.GetComponent<CellPosition>();
                Cell_Position = _sc_Cell.Cell_Pos;
                target = hit.collider.gameObject.transform.position;
                if(hit.collider.gameObject.GetComponent<CellPosition>().IsWalkable == true)
                {
                    CanWalk = true;
                    TargetGetted = true;
                     PM_Manager();
                }else CanWalk = false;
                
                }
                if (gameObject.GetComponent<Show_Pattern>().PunchPattern.activeInHierarchy == true)
                {
                   // Debug.Log(enemy_Position + "=" + hit.collider.transform.position );
                     FindEnemy();
                   
                    if (hit.collider.transform.position == enemy_Position)
                    {
                        Debug.Log(hit.collider.gameObject.layer);
                      
                        if (hit.collider.tag == "Punch") { 
                            tile = hit.collider.gameObject;
                            Current_PA -= hit.collider.GetComponent<Spell>().Cout_En_PA;
                            DamageType();
                        }
                        if(hit.collider.tag != "Punch")
                        {
                            Current_PA -= 5;
                            EnemyClickedDamageType();
                            
                        }
                        
                        
                        
                       
                       
                       
                    }
                }
                if (gameObject.GetComponent<Show_Pattern>().RangePattern.activeInHierarchy == true)
                {
                  
                    
                    if (hit.collider.transform.position == enemy_Position)
                    {
                        Debug.Log(hit.collider.gameObject.layer);
                        if (hit.collider.tag == "Range")
                        {   tile = hit.collider.gameObject;
                             Current_PA -= hit.collider.GetComponent<Spell>().Cout_En_PA;
                            DamageType();
                        }
                        if (hit.collider.tag != "Range")
                        {
                            Current_PA -= 3;
                            EnemyClickedDamageType();

                        }

                    }
                }


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
        gameObject.GetComponent<Show_Pattern>().Default();
        PlayerEndTurn = false;
         Current_PM = Max_PM;
        Current_PA = Max_PA;
      
        
    }
    void ShootRaycast()
    {
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, RightRay ,1 , CollisionLayerMask) ;
       
       
        RaycastHit2D hitleft  = Physics2D.Raycast(transform.position, LeftRay, 1, CollisionLayerMask);
        if (hitright.collider != null)
        {
            TileRightRay.GetComponent<CellPosition>().EnemyCase = true;
        }
        if(hitright.collider == null)
        {
            TileRightRay.GetComponent<CellPosition>().EnemyCase = false;
        }
        if(hitleft.collider != null)
        {
            TileLeftRay.GetComponent<CellPosition>().EnemyCase = true;
        }
        if(hitleft.collider == null)
        {
            TileLeftRay.GetComponent<CellPosition>().EnemyCase = false;
        }

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


        if(hitup.collider != null)
        {
            TileTopRay.GetComponent<CellPosition>().EnemyCase = true;
        }
        if(hitup.collider == null)
        {
            TileTopRay.GetComponent<CellPosition>().EnemyCase = false;
        }
        if(hitdown.collider != null)
        { 
            TileBotRay.GetComponent<CellPosition>().EnemyCase = true;
        }
        if(hitdown.collider == null)
        {
            TileBotRay.GetComponent<CellPosition>().EnemyCase = false;
        }
      
        
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
    void CheckPlayerPosition()
    {
        if(CharacterPosition == target)
        {
            IsCorner = false;
        }
        if(transform.position.y > target.y)
        {
            invertMovePattern = true;
        }
        else { invertMovePattern = false; }
        foreach(Vector2 _corner in Corner)
        {
            if(CharacterPosition == _corner)
            {
                IsCorner = true;
            }
          
        }
    }
    void FindEnemy()
    {
        enemy_Position = enemy.transform.position;
    }
    void DamageType()
    {
        DamageToDeal = UnityEngine.Random.Range(tile.GetComponent<Spell>().Degat_Minimum, tile.GetComponent<Spell>().Degat_Maximum);        
        enemy.GetComponent<Manequin>().current_hp -= DamageToDeal;
        enemy.GetComponent<Manequin>().Clicked = true;
        _damage.SetBool("Damaged", true);
        StartCoroutine(ResetBool());
    }
    void EnemyClickedDamageType()
    {
        if (gameObject.GetComponent<Show_Pattern>().RangePattern.activeInHierarchy == true)
        {
            DamageToDeal = UnityEngine.Random.Range(2,15);
            enemy.GetComponent<Manequin>().current_hp -= DamageToDeal;
            enemy.GetComponent<Manequin>().Clicked = true;
            _damage.SetBool("Damaged", true);
            StartCoroutine(ResetBool());
        }
        if (gameObject.GetComponent<Show_Pattern>().PunchPattern.activeInHierarchy == true)
        {
            DamageToDeal = 10;
            enemy.GetComponent<Manequin>().current_hp -= DamageToDeal;
            enemy.GetComponent<Manequin>().Clicked = true;
            _damage.SetBool("Damaged", true);
            StartCoroutine(ResetBool());
        }
    }
    void CheckPA()
    {
        if (Current_PA < 0)
        {
            Current_PA = 0;

        }
    }
    IEnumerator ResetBool()
    {
        yield return new WaitForSeconds(0.35f);
        enemy.GetComponent<Manequin>().Clicked = false;
        _damage.SetBool("Damaged", false);

    }
   
   
}
