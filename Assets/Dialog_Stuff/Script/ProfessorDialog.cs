using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ProfessorDialog : MonoBehaviour
{
    bool IsChosing;
    public string World1;
    public GameObject DialogStuff;
    public GameObject ChoiceStuff;
    public List<DialogLine> ProfLine = new List<DialogLine>();
    public TextMeshProUGUI _text;
    public int index = 1;
    public int ChoiceLine_index;
    bool DialogEnd;
    public static bool IsBoy;
    public static bool IsGirl;

    private void Start()
    {
        DialogStuff.SetActive(true);
        ChoiceStuff.SetActive(false);
        _text.text = ProfLine[0].CharacterLine;
    }
    private void Update()
    {
        if (!IsChosing)
        {
             ReadDialog();
        }
            
        
       
    }
    void ReadDialog()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {

            if(index == ChoiceLine_index)
            {
                IsChosing = true;
                DialogStuff.SetActive(false);
                ChoiceStuff.SetActive(true);
            }
            else
            {
                DialogStuff.SetActive(true);
                ChoiceStuff.SetActive(false);
            }

            if (index >= ProfLine.Count )
            {

                SceneManager.LoadScene(World1);
            }
            else
            {
                

                _text.text = ProfLine[index].CharacterLine;
                index++;
            }
        }
    }
    public void GirlChoice()
    {
        IsGirl = true;
        IsChosing = false;
        DialogStuff.SetActive(true);
        ChoiceStuff.SetActive(false);
    }
    public void BoyChoice()
    {
        IsBoy = true;
        IsChosing = false;
        DialogStuff.SetActive(true);
        ChoiceStuff.SetActive(false);
    }
}
