using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    bool Boy;
    bool Girl;
    public GameObject BoyComp;
    public GameObject GirlComp;
    void Start()
    {
        Boy = ProfessorDialog.IsBoy;
        Girl = ProfessorDialog.IsGirl;
        if (Boy)
        {
            BoyComp.SetActive(true);
        }
        if (Girl)
        {
            GirlComp.SetActive(true);
        }
    }

    
}
