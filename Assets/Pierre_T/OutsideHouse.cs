using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideHouse : MonoBehaviour
{
    public EventHouse _TriggerEvent;
    GameObject OutsideGrid;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        _TriggerEvent.Exit.Invoke();
    }
    
}
