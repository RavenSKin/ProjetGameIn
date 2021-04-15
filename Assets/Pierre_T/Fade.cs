using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public GameObject _Outside;
    public GameObject Character;
    private Animator _anim;

    private void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
    }
    public void FadeScreen()
    {
        _anim.SetBool("IsFading", true);
    }
    public void SpawnCharacter()
    {
        Character.GetComponent<Movement>().enabled = true;
        _anim.SetBool("IsFading", false);
    }
    public void DeSpawnCharacter()
    {
        Character.GetComponent<Movement>().enabled = false;
      
    }
  
}
