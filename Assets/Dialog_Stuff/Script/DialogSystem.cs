using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DialogSystem : MonoBehaviour
{


    public static bool Validation;
    public List<DialogLine> Event_Line = new List<DialogLine>();
     GameObject _PlayerCharacter;
    bool OnCollision;
    bool DialogEnd;

    [Header("PNJ important")]
    public bool BeginTask;
    public bool HaveTask;
    public bool PNJ_Ankama;
    public int TaskIndex;

    [Header("Commun à tout les PNJ")]
    public GameObject _textCanvas;
    public List<DialogLine> PNJ_Line = new List<DialogLine>();
    public TextMeshProUGUI _text;
    public int index = 0;
    public int index_ankama = 0;


    void Start()
    {
       



    }

    // Update is called once per frame
    void Update()
    {
        
        if (HaveTask && index == TaskIndex && !PNJ_Ankama)
        {

            Tasks.Invoke();

        }
        if (HaveTask && index_ankama == TaskIndex && PNJ_Ankama)
        {
            Tasks.Invoke();
        }


        if (OnCollision)
        {
           

            if (Input.GetKeyUp(KeyCode.Space))
            {
               

                if (index >= PNJ_Line.Count || !OnCollision) // Dialogue pnj normal
                {
                   
                        _PlayerCharacter.GetComponent<Movement>().CanMove = true;
                   

                    _textCanvas.SetActive(false);
                    index = 0;
                    
                }
               else
                {

                    
                    _PlayerCharacter.GetComponent<Movement>().CanMove = false;
                    
                    _textCanvas.SetActive(true);

                    _text.text = PNJ_Line[index].CharacterLine;
                    index++;
                }
                if (index_ankama < Event_Line.Count  && Validation && PNJ_Ankama)
                {
                    
                    _PlayerCharacter.GetComponent<Movement>().CanMove = false;
                    
                    _textCanvas.SetActive(true);

                    _text.text = Event_Line[index_ankama].CharacterLine;
                    index_ankama++;
                }
            }

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.gameObject.tag == "Player")
        {
            _PlayerCharacter = collision.gameObject;

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {



        if (collision.gameObject.tag == "Player")
        {
            OnCollision = true;

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnCollision = false;

        }
    }
    public UnityEvent Tasks;
    public void Work()
    {
        Debug.Log("It work");
    }
    public void ValidateAnkamaTask()
    {
        DialogSystem.Validation = true;
    }
} 
    

