using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction_Porte : MonoBehaviour
{
   
    bool IsInsideTrigger;
    GameObject Door;
   
    private void Update()
    {
        if (IsInsideTrigger)
        {
            if (Door.GetComponent<Porte>().InsideHouse == false)
            {
                
                if (Input.GetKey(KeyCode.Z))
                {
                    StartCoroutine(FadeScreenOutside());
                    
                }
            }
            if (Door.GetComponent<Porte>().InsideHouse == true)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    StartCoroutine(FadeScreenInside());
                   
                }
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Door")
        {
           
          IsInsideTrigger = true;
            
          Door = collision.gameObject;
        }
      
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Door")
        {
             IsInsideTrigger = false;
             Door = null;
        }
       
    }
    IEnumerator FadeScreenOutside()
    {
        Fade.FadeScreen();
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(Door.GetComponent<Porte>().scene_name);
    }
    IEnumerator FadeScreenInside()
    {
        Fade.FadeScreen();
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(Door.GetComponent<Porte>().scene_name);
    }

}
