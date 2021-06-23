using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Sort { Degat , Buff, Debuff };


public class Spell : MonoBehaviour
{
    SpriteRenderer _sprite;
    Collider2D _collider;
    Color _standardColor;
    Color _alphacolor;
    bool OutBound;
    
    float boundsLeft = -3;
    float boundsRight = 12;
    float boundsUp = 0;
    float boundsDown = -7f;
    Vector2 Cell_WorldPos;
    GameObject character;
    public string NomDuSort;
    public int Degat_Minimum;
    public int Degat_Maximum;
    public int Cout_En_PA;
    public bool OutBounds;
    public List<GameObject> NextTile = new List<GameObject>();
    [HideInInspector]public bool Clickable;
    public Sort Type_De_Sort;

    private void Start()
    {
        _collider = gameObject.GetComponent<Collider2D>();
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _alphacolor.a = 0;
        _standardColor = _sprite.color;
        character = GameObject.FindGameObjectWithTag("Player");

    }
    private void Update()
    {
        OutOfBound();
        if (OutBounds || OutBound)
        {
            _sprite.color = _alphacolor;
            _collider.enabled = false;
        }
        else
        {
            _sprite.color = _standardColor;
            _collider.enabled = true;
        }
        
        if(character.GetComponent<Player_Manager>().Current_PA < Cout_En_PA)
        {
            Clickable = false;

        }
        else { Clickable = true; }
    }
    void OutOfBound()
    {
        Cell_WorldPos = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
        if (Cell_WorldPos.x < boundsLeft || Cell_WorldPos.x > boundsRight || Cell_WorldPos.y < boundsDown || Cell_WorldPos.y > boundsUp)
        {
            OutBound = true;
        }
        else OutBound = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.gameObject.tag == "Enemy")
        {
            foreach (GameObject tile in NextTile)
            {
                tile.GetComponent<Spell>().OutBounds = true;
            }
        }
       
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
         if(collision.gameObject.tag == "Enemy")
        {
            foreach (GameObject tile in NextTile)
            {
                tile.GetComponent<Spell>().OutBounds = false;
            }
        }
       
    }
   
}
