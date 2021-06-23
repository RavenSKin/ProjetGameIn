using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Moovement : MonoBehaviour
{

    public bool b_Player;
    public float f_speed;
    public Rigidbody2D rb_player;

    [Space]
    private float f_movement;

    [Space]
    public Vector2 v2_startpos;


    // Start is called before the first frame update
    void Start()
    {
        v2_startpos = transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
        f_movement = Input.GetAxisRaw("Vertical");

           rb_player.velocity = new Vector2(rb_player.velocity.x, f_movement * f_speed);
    }

    public void ResetPos()
    {
        rb_player.velocity = Vector2.zero;
        transform.position = v2_startpos;
    }
}
