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

    public TextMeshProUGUI pointsText;
    private int pointsNum;
    private int totalSocialPoints;
    private int totalEcologyPoints;
    private int totalEconomyPoints;
    private int highscore;

    void Awake()
    {
        if (PlayerPrefs.HasKey("socialpoints"))
        {
            totalSocialPoints = PlayerPrefs.GetInt("socialpoints");
        }

        if (PlayerPrefs.HasKey("ecologypoints"))
        {
            totalEcologyPoints = PlayerPrefs.GetInt("ecologypoints");
        }

        if (PlayerPrefs.HasKey("economypoints"))
        {
            totalEconomyPoints = PlayerPrefs.GetInt("economypoints");
        }

        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetInt("highscore");
        }

        Debug.Log("Social points: " + PlayerPrefs.GetInt("socialpoints") + " " + "Ecology points: " + PlayerPrefs.GetInt("ecologypoints") + " " + "Economy points: " + PlayerPrefs.GetInt("economypoints"));

        Debug.Log("Highscore: " + PlayerPrefs.GetInt("highscore"));

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
            options[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
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
                btn.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                
                pointsNum = pointsNum + question.socialPoints + question.ecologyPoints + question.economyPoints;
                pointsText.text = "Points: " + pointsNum;

                totalSocialPoints = totalSocialPoints + question.socialPoints;
                PlayerPrefs.SetInt("socialpoints", totalSocialPoints);

                totalEcologyPoints = totalEcologyPoints + question.ecologyPoints;
                PlayerPrefs.SetInt("ecologypoints", totalEcologyPoints);

                totalEconomyPoints = totalEconomyPoints + question.economyPoints;
                PlayerPrefs.SetInt("economypoints", totalEconomyPoints);

                PlayerPrefs.SetInt("answeredId_" + question.questionId, question.questionId);

                if (pointsNum > highscore)
                {
                    highscore = pointsNum;
                    PlayerPrefs.SetInt("highscore", highscore);
                }

                PlayerPrefs.Save();
            }
            else
            {
                btn.image.color = wrongCol;
                btn.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            }
        }
        
    }

}
