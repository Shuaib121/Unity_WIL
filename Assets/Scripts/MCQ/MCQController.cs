﻿using System.Collections;
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
    List<MCQTable>list = new List<MCQTable>();
    private DataService ds = new DataService("MainDatabase.db");
    private string mcqTitle;
    bool flag = true;

    private void Update()
    {
        if(questionNumber > 4)
        {
            questionTxt.text = "TEST COMPLETE\n\nYou Scored "+score+"/5";
            ansBtnOne.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
            ansBtnTwo.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
            ansBtnThree.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
            ansBtnFour.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);

            if (flag)
            {
                User.MCQCorrectCount += score;
                if (score == 5)
                {
                    User.MCQPerfectCount++;
                }
                flag = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mcqTitle = FindObjectOfType<ChosenOption>().GetTitle();
        PopulateList();
        DisplayFirstOption();
    }
    public void PopulateList()
    {
        var mcq = ds.GetMCQ();
        foreach (var questionData in mcq)
        {
            if (questionData.testName == mcqTitle)
            {
                list.Add(questionData);
            }
        }
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
            AudioSource.PlayClipAtPoint(CorrectSound, Camera.main.transform.position);
            score++;
        }
        else
        {
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
                questionNumberTxt.text = "Q:2/5";
                break;
            case 2:
                questionNumberTxt.text = "Q:3/5";
                break;
            case 3:
                questionNumberTxt.text = "Q:4/5";
                break;
            case 4:
                questionNumberTxt.text = "Q:5/5";
                break;
        }
    }
}
