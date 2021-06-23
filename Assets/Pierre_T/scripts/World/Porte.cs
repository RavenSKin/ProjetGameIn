using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    [Header(" Cocher si le trigger est dans une maison")]
    public bool InsideHouse;
    [Header("Nom de la scene sur laquelle basculer")]
    public string scene_name;
    [Header("Cocher dans quel maison se trouve le trigger")]
    public bool InsideAnkama;
    public bool InsideChroniric;
    public bool InsideEArt;
    public bool InsideCGC;

    private void Start()
    {
        if (InsideAnkama)
        {
            PositionManager.Ankama_Door_bool = true;
        }
        if (InsideCGC)
        {
            PositionManager.CGC_Door_bool = true;
        }
        if (InsideChroniric)
        {
            PositionManager.Chroniric_Door_bool = true;
        }
        if (InsideEArt)
        {
            PositionManager.E_ArtDoor_bool = true;
        }
    }
}
