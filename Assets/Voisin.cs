using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voisin: MonoBehaviour
{
    public bool IsPlayerOff;
    public int count;
    public int NeighborDisabledCount;
    bool NeighborActivated; 
    public bool IsPlayerOn;
    public List<GameObject> CellToDisable = new List<GameObject>();
    public List<GameObject> CellToEnable = new List<GameObject>();
    public List<GameObject> _neighbor = new List<GameObject>();
    CollisionDetection _collDetect;
    // Start is called before the first frame update
    private void Start()
    {
        _collDetect = GameObject.FindGameObjectWithTag("Player").GetComponent<CollisionDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
       
       
    
       
    }
    public void PlayerOn()
    {
        if (IsPlayerOn)
        {
            foreach (GameObject _cell in CellToDisable)
            {
                _cell.GetComponent<CellPosition>().UpperLinkedOn();
            }
            foreach (GameObject _cell in CellToEnable)
            {
                _cell.GetComponent<CellPosition>().UpperLinkedOff();
            }
        }
    }
    public void PlayerOff()
    {
        if (!IsPlayerOn)
        {
            foreach (GameObject _cell in CellToDisable)
            {
                _cell.GetComponent<CellPosition>().UpperLinkedOff();
            }
            foreach (GameObject _cell in CellToEnable)
            {
                _cell.GetComponent<CellPosition>().UpperLinkedOff();
            }
        }
    }
}
