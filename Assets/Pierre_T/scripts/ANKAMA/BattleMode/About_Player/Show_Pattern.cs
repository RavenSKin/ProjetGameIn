using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Pattern : MonoBehaviour
{
    public float Player_PA;
    public GameObject RangePattern;
    public GameObject PunchPattern;
    public GameObject MovePattern;
   public bool DisplayPunchPattern;
    public bool DisplayThrowPattern;
    bool IsMoving;
    bool IsThrowing;
    bool IsPunching;
    private void Start()
    {
        Default();
    }
    private void Update()
    {
        Player_PA = gameObject.GetComponent<Player_Manager>().Current_PA;
        if (IsMoving)
        {
            MovePattern.SetActive(true);
            RangePattern.SetActive(false);
            PunchPattern.SetActive(false);
        }
        if (IsThrowing)
        {
        
            if(Player_PA<2)
            {
                RangePattern.SetActive(false);
       
            }
            if (Player_PA >= 2)
            { 
             RangePattern.SetActive(true);
             PunchPattern.SetActive(false);
             MovePattern.SetActive(false);
        
            }
        }
        if (IsPunching)
        {
            if (Player_PA < 5)
            {
                PunchPattern.SetActive(false);
            }
            if(Player_PA >= 5)
            {
                RangePattern.SetActive(false);
                PunchPattern.SetActive(true);
                MovePattern.SetActive(false);
            }
        }
        
       
    }
    public void Default()
    {
        RangePattern.SetActive(false);
        PunchPattern.SetActive(false);
        MovePattern.SetActive(true);
    }
    public void ThrowRock()
    {

        if (Player_PA>=2)
        {
            IsThrowing = true;
            IsPunching = false;
            IsMoving = false;
        }
        

    }
    public void Punch()
    {
        if(Player_PA>=5 )
        {
            IsPunching = true;
            IsThrowing = false;
            IsMoving = false;
        }
       
    }
    public void Move()
    {
        IsMoving = true;
        IsPunching = false;
        IsThrowing = false;
    }
    
}
