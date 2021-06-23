using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager_Pong : MonoBehaviour
{

    public int i_ScoreIA;
    public int i_ScorePlayer;

    [Space]

    public Text TxT_ScoreIA;
    public Text TxT_ScorePlayer;

    [Space]

    public bool b_PingPong;
    public bool b_Hunt;


    [Space]

    public string st_MiniGame;

    [Space]
    public GameObject gm_player;
    public GameObject gm_ball;
    public GameObject gm_paddleIA;

    [Space]
    [Header("Score")]

    public Text txt_ScorePlayer;
    public Text txt_scoreIA;

    public int i_scoreplayer;
    public int i_scoreIA;

    public float f_timer;

    // Start is called before the first frame update
    void Start()
    {
        gm_player = GameObject.Find("Player");
        gm_ball = GameObject.Find("Ball");
        gm_paddleIA = GameObject.Find("IA");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }

        txt_scoreIA.text = i_scoreIA.ToString();
        txt_ScorePlayer.text = i_scoreplayer.ToString();

        f_timer -= Time.deltaTime;


        if (f_timer <= 0)
        {
            //faire avancer les joueurs plus proches du centre

        }
    }

    public void ResetPosition()
    {

        gm_ball.transform.position = gm_ball.GetComponent<SC_Ball>().v2_Startpos;
        gm_ball.GetComponent<SC_Ball>().Launch();

        gm_player.transform.position = gm_player.GetComponent<SC_Moovement>().v2_startpos;

        gm_paddleIA.GetComponent<SC_Moovement>().ResetPos();
        gm_paddleIA.GetComponent<SC_IA>().ResetPos();
    }

    public void Quit()
    {
        Application.Quit();
    }






    public void AddScorePlayer()
    {
        i_scoreplayer++;

    }

    public void AddScoreIA()
    {

        i_scoreIA++;

    }
}
