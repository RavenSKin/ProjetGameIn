using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manequin : MonoBehaviour
{
   [HideInInspector] public int damages;
    StateManager _manager;
    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI damagesText;
    public GameObject HealthCanvas;
   [HideInInspector]public int current_hp;
     public bool Clicked;
    public GameObject Male;
    public GameObject Female;

   public int MaxHp;
    Vector3 CurrentPosition;
    void Start()
    {
        _manager = GameObject.Find("Manager").GetComponent<StateManager>();
        current_hp = MaxHp;
      
      
    }

 
    void Update()
    {
         
       
        if (Clicked)
        {
            if(Male.activeInHierarchy == true)
            {
                damages = Male.GetComponent<Player_Manager>().DamageToDeal;
               
            }
            if(Female.activeInHierarchy == true)
            {
               
                damages = Female.GetComponent<Player_Manager>().DamageToDeal;
            }
           
            
        }
        else
        {

        }
        
        textMesh.text = current_hp + "/" + MaxHp;
        CurrentPosition = transform.position;
        damagesText.text = damages.ToString();
        if(current_hp <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(Win());
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Enemy")
            {
                HealthCanvas.SetActive(true);
            }
        }
        if(hit.collider == null)
        {
            HealthCanvas.SetActive(false);
        }
       
    }
   
   IEnumerator Win()
    {
        Inventory.is_Ankama_Badge = true;
        yield return new WaitForSeconds(1);
        PositionManager.Ankama_Epreuve_bool = true;
        _manager.World_1();

    }
}
