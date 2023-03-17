using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = System.Random;
using System.Linq;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private List<Button> options;
    [SerializeField] private Color correctCol, wrongCol, normalCol;

    private Question question;
    private bool answered;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
    }


    public void SetQuestion(Question question)
    {
        this.question = question;


        questionText.text = question.questionInfo;


        Random rand = new Random();
        List<string> answerList = question.options.OrderBy(_ => rand.Next()).ToList();

        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = normalCol;
        }

        answered = false;
    }

    private void OnClick(Button btn)
    {
        if (!answered)
        {
            answered = true;
            bool val = quizManager.Answer(btn.name);

            if (val)
            {
                btn.image.color = correctCol;
            }
            else
            {
                btn.image.color = wrongCol;
            }
        }
    }

}
