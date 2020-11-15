using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Gui;
using UnityEngine.UI;

public class MCQController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ansBtnOne;
    [SerializeField] TextMeshProUGUI ansBtnTwo;
    [SerializeField] TextMeshProUGUI ansBtnThree;
    [SerializeField] TextMeshProUGUI ansBtnFour;
    [SerializeField] TextMeshProUGUI questionTxt;
    [SerializeField] TextMeshProUGUI questionNumberTxt;
    [SerializeField] AudioClip CorrectSound;
    [SerializeField] AudioClip IncorrectSound;
    [SerializeField] LeanWindow incorrectDisplay;

    private int score = 0;
    private int questionNumber = 0;
    List<MCQObject> list = new List<MCQObject>();

    private void Update()
    {
        if(questionNumber > 4)
        {
            questionTxt.text = "TEST COMPLETE\n\nYou Scored "+score+"/5";
            ansBtnOne.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
            ansBtnTwo.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
            ansBtnThree.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
            ansBtnFour.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        MCQObject Q1 = new MCQObject()
        {
            question = "What colour is the sun?",
            optionOne = "Black",
            optionTwo = "Blue",
            optionThree = "Purple",
            optionFour = "Yellow",
            answer = "Yellow"
        };

        MCQObject Q2 = new MCQObject()
        {
            question = "What colour is the Moon",
            optionOne = "Black",
            optionTwo = "White",
            optionThree = "Purple",
            optionFour = "Yellow",
            answer = "White"
        };

        MCQObject Q3 = new MCQObject()
        {
            question = "What colour is a Lion?",
            optionOne = "Black",
            optionTwo = "Blue",
            optionThree = "Brown",
            optionFour = "Yellow",
            answer = "Brown"
        };

        MCQObject Q4 = new MCQObject()
        {
            question = "What is 1+1?",
            optionOne = "3",
            optionTwo = "7",
            optionThree = "69",
            optionFour = "2",
            answer = "2"
        };

        MCQObject Q5 = new MCQObject()
        {
            question = "What is 10+10",
            optionOne = "13",
            optionTwo = "17",
            optionThree = "21",
            optionFour = "20",
            answer = "20"
        };

        list.Add(Q1);
        list.Add(Q2);
        list.Add(Q3);
        list.Add(Q4);
        list.Add(Q5);

        DisplayFirstOption();
    }


    private void DisplayFirstOption()
    {
        questionTxt.text = list[0].question;
        ansBtnOne.text = list[0].optionOne;
        ansBtnTwo.text = list[0].optionTwo;
        ansBtnThree.text = list[0].optionThree;
        ansBtnFour.text = list[0].optionFour;
    }
    public void DisplayOptions(TextMeshProUGUI chosenAnswer)
    {
        CheckAnswer(chosenAnswer);
        questionNumber++;
        questionTxt.text = list[questionNumber].question;
        ansBtnOne.text = list[questionNumber].optionOne;
        ansBtnTwo.text = list[questionNumber].optionTwo;
        ansBtnThree.text = list[questionNumber].optionThree;
        ansBtnFour.text = list[questionNumber].optionFour;

    }

    private void CheckAnswer(TextMeshProUGUI chosenAnswer)
    {

        if (chosenAnswer.text == list[questionNumber].answer)
        {
            Debug.Log("CORRECT: " +chosenAnswer.text +" "+ list[questionNumber].answer);
            AudioSource.PlayClipAtPoint(CorrectSound, Camera.main.transform.position);
            score++;
        }
        else
        {
            Debug.Log("INCORRECT" + chosenAnswer.text + " " + list[questionNumber].answer);
            AudioSource.PlayClipAtPoint(IncorrectSound, Camera.main.transform.position);
            incorrectDisplay.GetComponentInChildren<Text>().text = "<size=60>Wrong Answer!</size> \n\nQuestion: "+list[questionNumber].question+"\n\nCorrect Answer: " + list[questionNumber].answer;
            incorrectDisplay.TurnOn();
        }
    }

    public void SetQuestionNumberDisplay()
    {
        switch (questionNumber)
        {
            case 1:
                questionNumberTxt.text = "2/5";
                break;
            case 2:
                questionNumberTxt.text = "3/5";
                break;
            case 3:
                questionNumberTxt.text = "4/5";
                break;
            case 4:
                questionNumberTxt.text = "5/5";
                break;
        }
    }
}
