using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockSight : MonoBehaviour
{   
    Vector3 CurrentTransform;

    [Header("Droite")]
    [Space]
    public List<Vector3>LeftBlockingSight = new List<Vector3>();

    public List<GameObject> RightTile = new List<GameObject>();

  

    public bool RightCollide ;

    [Header("Gauche")]
    [Space]

    public List<Vector3>RightBlockingSight = new List<Vector3>();
    public List<GameObject> LeftTile = new List<GameObject>();
 
    public bool LeftCollide;
    
    [Header("Bas")]
    [Space]

    public List<Vector3>DownBlockingSight = new List<Vector3>();
    public List<GameObject> TopTile = new List<GameObject>();

  public bool TopCollide;

    [Header("Haut")]
    [Space]

    public List<Vector3>TopBlockingSight = new List<Vector3>();
    public List<GameObject> BotTile = new List<GameObject>();
 
    public bool BotCollide;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Setup();
        AllWayCollision();
      
        foreach(Vector3 tile_L in LeftBlockingSight)
        {
            if(CurrentTransform == tile_L )
            {
               RightCollide = true;
            }else{RightCollide = false;}
        }
          foreach(Vector3 tile_R in RightBlockingSight)
        {
            if(CurrentTransform == tile_R )
            {
               LeftCollide = true;
            }else{LeftCollide = false;}
        }

        foreach(Vector3 tile_B in DownBlockingSight)
        {
            if(CurrentTransform == tile_B )
            {
               TopCollide = true;
            }else{TopCollide = false;}
        }
        foreach(Vector3 tile_T in TopBlockingSight)
        {
            if(CurrentTransform == tile_T )
            {
               BotCollide = true;
            }else{BotCollide = false;}
        }
    }
    void Setup()
    {
        CurrentTransform = new Vector3(Mathf.Round(transform.position.x)  , Mathf.Round(transform.position.y) , Mathf.Round(transform.position.z) );
    }
   void AllWayCollision()
    {
                             // ======           Right         ====//
        if(RightCollide)
        {
            foreach(GameObject tile_R in RightTile)
            {
                tile_R.GetComponent<CellPosition>().UpperLinked = true;
            }
        }
        else{
             foreach(GameObject tile_R in RightTile)
            {
                tile_R.GetComponent<CellPosition>().UpperLinked = false;
            }

        }
                             // ======           Left         ====//
        if(LeftCollide)
        {
            foreach(GameObject tile_L in LeftTile)
            {
                tile_L.GetComponent<CellPosition>().UpperLinked = true;
            }
        }else
        {
            foreach(GameObject tile_L in LeftTile)
            {
                tile_L.GetComponent<CellPosition>().UpperLinked = false;
            }
        }
                             // ======           Bot         ====//
        if(BotCollide)
        {
            foreach(GameObject tile_B in BotTile)
            {
                 tile_B.GetComponent<CellPosition>().UpperLinked = true;
            }
        }else
        {
            foreach(GameObject tile_B in BotTile)
            {
                 tile_B.GetComponent<CellPosition>().UpperLinked = false;
            }
        }
                             // ======           Top         ====//
        if(TopCollide)
        {
            foreach(GameObject tile_T in TopTile)
            {
                tile_T.GetComponent<CellPosition>().UpperLinked = true;
            }
        }else
        {
             foreach(GameObject tile_T in TopTile)
            {
                tile_T.GetComponent<CellPosition>().UpperLinked = false;
            }
        }
    }

}

    // VECTOR (FAIT ) 

    // BOOL 
// TL_COLLIDE , TR_COLLIDE
// BL_COLLIDE , BR_COLLIDE
// RT_COLLIDE , RB_COLLIDE
// LT_COLLIDE , LB_COLLIDE

// POUR CHAQUE VECTEUR DANS CHAQUE ELEMENT SI LA POSITION DU JOUEUR EST LA MEME QUE CELLE LA : LE BOOLEEN LIE VAUX VRAI SINON FAUX 
// probleme : il y  des conflits entre les booleen
