using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CollisionDetection : MonoBehaviour
{
    bool ResetTile; // booleen qui renvoie vrai si le joueur n'es pas sur une disablePlaces
    public List<GameObject> AvailablePosition = new List<GameObject>();
    public List<GameObject> DisablePlaces = new List<GameObject>();
    public List<GameObject> Cells = new List<GameObject>();
   
    GameObject Character;
    Vector3 char_pos;
    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        CorrectPositionSetup();
        NonCorrectPositionSetup();
        ResetTileSetup();
        char_pos = new Vector3(Mathf.Round(Character.transform.position.x), Mathf.Round(Character.transform.position.y), 0);
       
            
        }
    void ResetTileSetup()
    {


        if (ResetTile)
        {
            foreach (GameObject _places in DisablePlaces)
            {
                _places.GetComponent<Voisin>().IsPlayerOn = false;
            }
            foreach(GameObject _cell in Cells)
            {
                _cell.GetComponent<CellPosition>().UpperLinkedOff();
            }
        }
        if (!ResetTile)
        {
           foreach (GameObject _places in DisablePlaces)
           {

              if (char_pos == _places.transform.position)
              {
                   
                 _places.GetComponent<Voisin>().IsPlayerOn = true;
                 _places.GetComponent<Voisin>().PlayerOn();



              }
               else
               {
                 _places.GetComponent<Voisin>().IsPlayerOn = false;
               }

           }
        }
    }
        void CorrectPositionSetup()
        {
             if (AvailablePosition.Count > 0)
             {
                      foreach (GameObject _position in AvailablePosition)
                      {
                         if (char_pos == _position.transform.position)
                         {
                             ResetTile = true;
                             
                            
                         }

                      }      
             }
    
        }

        void NonCorrectPositionSetup()
        {
           if (DisablePlaces.Count > 0)
           {
               
                    foreach (GameObject _places in DisablePlaces)
                    {

                        if (char_pos == _places.transform.position)
                        {
                              ResetTile = false;

                        }
                        else
                        {
                            _places.GetComponent<Voisin>().IsPlayerOn = false;
                        }

                    }
              
           }

        }

    
}