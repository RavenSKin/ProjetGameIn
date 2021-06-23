using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static bool is_Ankama_Badge;
    public static bool is_Chroniric_Badge;
    public static bool is_E_artSup_Badge;
    public static bool is_CGC_Badge;
    [SerializeField] Color baseColor;
    [SerializeField] GameObject Ankama_Badge;
    [SerializeField] GameObject Chroniric_Badge;
    [SerializeField] GameObject E_artSup_Badge;
    [SerializeField] GameObject CGC_Badge;
    public GameObject UI_Inventory;
    
    GameObject character;
    private void Start()
    {
        
        UI_Inventory.SetActive(false);
    }
    private void Update()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        if (is_Ankama_Badge)
        {
            Ankama_Badge.GetComponent<Image>().color = baseColor;
        }
        if (is_Chroniric_Badge)
        {
            Chroniric_Badge.GetComponent<Image>().color = baseColor;
        }
        if (is_E_artSup_Badge)
        {
            E_artSup_Badge.GetComponent<Image>().color = baseColor;
        }
        if (is_CGC_Badge)
        {
            CGC_Badge.GetComponent<Image>().color = baseColor;
        }
    }
    public void ShowInventory()
    {
        UI_Inventory.SetActive(true);
        character.GetComponent<Movement>().CanMove = false;
    }
    public void HideInventory()
    {
        UI_Inventory.SetActive(false);
        character.GetComponent<Movement>().CanMove = true;
    }


}
