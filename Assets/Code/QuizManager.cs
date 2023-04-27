using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private QuizDataScriptable quizData;
    [SerializeField] private QuizDataScriptable quizDataEn;

    private List<Question> questions;

    private List<Question> unansweredQuestions = new List<Question>();

    private List<Question> answeredQuestions = new List<Question>();

    private List<Question> selectedQuestions = new List<Question>(); 

    private Question selectedQuestion;

    private int counter = 0;

    private int selection;

    void Start()
    {
        if (PlayerPrefs.GetString("Language") == "Finnish")
        {
            questions = quizData.questions;
        }
        
        if (PlayerPrefs.GetString("Language") == "English")
        {
            questions = quizDataEn.questions;
        }

        for (int i = 0; i < questions.Count(); i++)
        {
            if (PlayerPrefs.HasKey("answeredId_" + i ))
            {
                answeredQuestions.Add(questions [i]);
            }
            else
            {
                unansweredQuestions.Add(questions [i]);
            }
        }

        BuildQuestionList();
        SelectQuestion();
    }

    void BuildQuestionList()
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
        if (counter > 9)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
        Debug.Log(counter);
        Debug.Log(selectedQuestions.Count());

        selection = Random.Range(0, selectedQuestions.Count());

        selectedQuestion = selectedQuestions[selection];

        quizUI.SetQuestion(selectedQuestion);

        selectedQuestions.RemoveAt(selection);

        counter++;
        }
        
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
