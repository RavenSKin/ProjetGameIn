using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
   public static bool Ankama_Door_bool;
   public static bool Ankama_Epreuve_bool;
   public static bool CGC_Door_bool;
   public static bool Chroniric_Door_bool;
   public static bool E_ArtDoor_bool;

   [SerializeField] Transform Ankama_Door;
   [SerializeField] Transform Ankama_Epreuve;
   [SerializeField] Transform CGC_Door;
   [SerializeField] Transform Chroniric_Door;
   [SerializeField] Transform E_ArtDoor;
    void Awake()
    {
        if (Ankama_Door_bool)
        {
            transform.position = Ankama_Door.position;
            Ankama_Door_bool = false;
        }
        if (Ankama_Epreuve_bool)
        {
            transform.position = Ankama_Epreuve.position;
            Ankama_Epreuve_bool = false;
        }
        if (CGC_Door_bool)
        {
            transform.position = CGC_Door.position;
            CGC_Door_bool = false;
        }
        if (Chroniric_Door_bool)
        {
            transform.position = Chroniric_Door.position;
            Chroniric_Door_bool = false;
        }
        if (E_ArtDoor_bool)
        {
            transform.position = E_ArtDoor.position;
            E_ArtDoor_bool = false;
        }
    }

   
}
