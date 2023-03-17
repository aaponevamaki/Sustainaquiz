using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private QuizDataScriptable quizData;

    private List<Question> questions;

    private Question selectedQuestion;

    // Start is called before the first frame update
    void Start()
    {
        questions = quizData.questions;

        SelectQuestion();
    }

    void SelectQuestion()
    {
        int val = Random.Range(0, questions.Count);
        selectedQuestion = questions[val];

        quizUI.SetQuestion(selectedQuestion);
    }

    public bool Answer(string answered)
    {
        bool correctAns = false;

        if (answered == selectedQuestion.correctAns)
        {
            correctAns = true;
        }
        else
        {

        }

        Invoke("SelectQuestion", 0.4f);
        return correctAns;
    }
}

[System.Serializable]
public class Question
{
    public string questionInfo;
    public List<string> options;
    public string correctAns;
    public int socialPoints;
    public int environmentPoints;
    public int economicPoints;
}
