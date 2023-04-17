using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private QuizDataScriptable quizData;

    private List<Question> questions;

    private static List<Question> unansweredQuestions;

    private Question selectedQuestion;

    // Start is called before the first frame update
    void Start()
    {
        questions = quizData.questions;

        unansweredQuestions = questions.ToList<Question>();

        SelectQuestion();
    }

    void Update()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
    }

    void SelectQuestion()
    {
        int val = Random.Range(0, unansweredQuestions.Count);
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
