using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Ball : MonoBehaviour
{
    public float f_speed;
    public Rigidbody2D rb_Ball;


    public GameManager_Pong sc_gamemanager;

    public Vector3 v2_Startpos;


   


    // Start is called before the first frame update
    void Start()
    {

        sc_gamemanager = GameObject.Find("GameManager").GetComponent<GameManager_Pong>();

        v2_Startpos = transform.position;

        Launch();    
    }


    public void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb_Ball.velocity = new Vector2(f_speed * x, f_speed * y);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("PlayerGoal"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager_Pong>().AddScorePlayer();
               
            sc_gamemanager.ResetPosition();
        }

        if(col.CompareTag("IAGoal"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager_Pong>().AddScoreIA();
            
            sc_gamemanager.ResetPosition();
            ResetPos();

        }
    }

   

    public void ResetPos()
    {
        rb_Ball.velocity = Vector2.zero;
        transform.position = v2_Startpos;
    }
}
