using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtions;
    [SerializeField] int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    void Start()
    {
        DisplayQuestion();
    }

    public void OnAnswerSelected(int index)
    {
        Image buttonImage;

        if(index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct";
            buttonImage = answerButtions[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = "Incorrect - the correct answer is \n" + correctAnswer;

            buttonImage = answerButtions[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        SetButtonState(false);
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprite();
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();

        for(int i = 0; i < answerButtions.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtions[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtions.Length; i++)
        {
            Button button = answerButtions[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    private void SetDefaultButtonSprite()
    {
        for(int i = 0; i < answerButtions.Length; i++)
        {
            Image buttonImage = answerButtions[i]. GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}

