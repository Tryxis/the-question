using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,5)]
    [SerializeField] string question = "Enter question text";

    public string GetQuestion()
    {
        return question;
    }
    
}
