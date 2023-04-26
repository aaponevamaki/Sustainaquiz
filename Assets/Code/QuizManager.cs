using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private QuizDataScriptable quizData;

    private List<Question> questions;

    private List<Question> unansweredQuestions;

    private List<Question> answeredQuestions;

    private List<Question> selectedQuestions;

    private Question selectedQuestion;

    // Start is called before the first frame update
    void Start()
    {
        //questions = quizData.questions;

        for (int i = 0; i < quizData.questions.Count(); i++)
        {
            if (PlayerPrefs.HasKey("answeredId_" + i ))
            {
                answeredQuestions.Add(quizData.questions [i]);
            }
            else
            {
                //unansweredQuestions.Add(quizData.questions [i]);
            }
        }

        SelectQuestion();
    }

    void buildQuestionList()
    {
        for (int i = 0; i < 10; i++)
        {
            int random = Random.Range(0,1);
            if (random > 0.75)
            {
                selectedQuestions.Add(answeredQuestions [Random.Range(0, answeredQuestions.Count() -1)]);
            }
            else
            {
                selectedQuestions.Add(unansweredQuestions [Random.Range(0, unansweredQuestions.Count() -1)]);
            }
        }
    }

    void SelectQuestion()
    {
        int val = Random.Range(0, 10);
        selectedQuestion = unansweredQuestions[val];

        quizUI.SetQuestion(selectedQuestion);

        unansweredQuestions.RemoveAt(val);
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
    public int questionId;
    public string questionInfo;
    public List<string> options;
    public string correctAns;
    public int socialPoints;
    public int ecologyPoints;
    public int economyPoints;
}
