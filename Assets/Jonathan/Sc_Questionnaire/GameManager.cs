using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Scénario : MonoBehaviour
{

    public Button btn_confirmed;


    [Space]
    [Header ("Espace Questions")]

    public Text txt_Question;

    [Space]
    [Header("Espace Réponse")]

    public Text txt_ReponseA;
    public Text txt_ReponseB;
    public Text txt_ReponseC;

    public Toggle tgl_reponseA;
    public Toggle tgl_reponseB;
    public Toggle tgl_reponseC;



    [Space]
    [Header("Gestion Next")]
    public Text txt_NumQuestion;
    public int int_NumQuestion = 1;
    public Image img_timer;


    // Start is called before the first frame update
    void Start()
    {
        txt_ReponseA.fontSize = 45;
        txt_ReponseB.fontSize = 45;
        txt_ReponseC.fontSize = 45;

    }

    // Update is called once per frame
    void Update()
    {
        txt_NumQuestion.text = int_NumQuestion.ToString();


        //Gestions des textes


        if(int_NumQuestion == 1)
        {
            txt_Question.text = "Quel est le moteur graphique de Fortnite?";

            txt_ReponseA.text = "Non VIVE les GA";
            txt_ReponseB.text = "Je ne sais pas du tout";
            txt_ReponseC.text = "Bien entendu ce sont des dieux";
        }

        if(int_NumQuestion == 2)
        {

            txt_Question.text = "Qui est le plus con ?";

            txt_ReponseA.text = "Non VIVE les GA";
            txt_ReponseB.text = "Je ne sais pas du tout";
            txt_ReponseC.text = "Bien entendu ce sont des dieux";

        }

        if(int_NumQuestion == 3)
        {

            txt_Question.text = "LOL";

            txt_ReponseA.text = "Non VIVE les GA";
            txt_ReponseB.text = "Je ne sais pas du tout";
            txt_ReponseC.text = "Bien entendu ce sont des dieux";

        }

        if(int_NumQuestion == 4)
        {
            txt_Question.text = "Les GD sont les meilleurs";

            txt_ReponseA.text = "Non VIVE les GA";
            txt_ReponseB.text = "Je ne sais pas du tout";
            txt_ReponseC.text = "Bien entendu ce sont des dieux";


        }
    }

    public void BonneReponse()
    {
        //jouer le son de réussite

        //Afficher la prochaine question
        NextQuestion();
    }

    public void Coucou()
    {
        
        if (int_NumQuestion == 1&& tgl_reponseA.isOn)
        {
            NextQuestion();
        }

    }


    public void NextQuestion()
    {
        int_NumQuestion += 1;
    }
}
