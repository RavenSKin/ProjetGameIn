using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
 
   
    private static Animator _anim;
    private void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        
    }

    public static void FadeScreen()
    {
        _anim.SetBool("IsFading", true);
       
    }
   public void StopFading()
    {
        _anim.SetBool("IsFading", false);
    }
  
  
}
