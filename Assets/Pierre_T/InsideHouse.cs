using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideHouse : MonoBehaviour
{
    public EventHouse _TriggerEvent;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _TriggerEvent.Enter.Invoke();
    }
}
