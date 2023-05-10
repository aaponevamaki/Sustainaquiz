using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats : MonoBehaviour
{
    private int ecology;
    private int economy;
    private int social;
    private int ecologyTotal;
    private int economyTotal;
    private int socialTotal;
    private string master;
    private string beginner;
    private string intermediate;
    private string economyMaster;
    private string ecologyMaster;
    private string socialMaster;
    private float socialPercentage;
    private float economyPercentage;
    private float ecologyPercentage;
    private float totalPercentage;

    //private float testFillValue = 0.5f;

    [SerializeField] private QuizDataScriptable QuizData;

    [SerializeField] private Image SocialGraph;
    [SerializeField] private Image EcologyGraph;
    [SerializeField] private Image EconomyGraph;

    [SerializeField] private TextMeshProUGUI SocialTitle;
    [SerializeField] private TextMeshProUGUI EcologyTitle;
    [SerializeField] private TextMeshProUGUI EconomyTitle;
    [SerializeField] private TextMeshProUGUI Title;

    [SerializeField] private TextMeshProUGUI SocialPoints;
    [SerializeField] private TextMeshProUGUI EcologyPoints;
    [SerializeField] private TextMeshProUGUI EconomyPoints;

    void Start()
    {
        ecology = PlayerPrefs.GetInt("ecologypoints");
        economy = PlayerPrefs.GetInt("economypoints");
        social = PlayerPrefs.GetInt("socialpoints");

        CalculateTotalPoints();

        socialPercentage = (float)social/(float)socialTotal;
        economyPercentage = (float)ecology/(float)ecologyTotal;
        ecologyPercentage = (float)economy/(float)economyTotal;
        totalPercentage = socialPercentage + economyPercentage + ecologyPercentage;
        
        SetGraphFill();
        SetText();

    }

    void CalculateTotalPoints()
    {
        foreach (Question question in QuizData.questions)
        {
            ecologyTotal += question.ecologyPoints;
            economyTotal += question.economyPoints;
            socialTotal += question.socialPoints;
        }
    }

    void SetText()
    {
        if (PlayerPrefs.GetString("Language") == "English")
        {
            master = "Master of Sustainability";
            beginner = "Sustainability Who?";
            intermediate = "Getting There!";
            economyMaster = "Master of Economy";
            ecologyMaster = "Master of Ecology";
            socialMaster = "Social Master";
        }
        else
        {
            master = "Kestävyyden Mestari";
            beginner = "Kestävä Mikä?";
            intermediate = "Melkein Mestari";
            economyMaster = "Talouden Mestari";
            ecologyMaster = "Luonnon Mestari";
            socialMaster = "Yhteiskunnan Mestari";
            SocialTitle.text = "Yhteiskunta";
            EcologyTitle.text = "Luonto";
            EconomyTitle.text = "Talous";
        }

        if (totalPercentage >= 3f)
        {
            Title.text = master;
        }
        else if (totalPercentage >= 1.5f)
        {
            Title.text = intermediate;
        }
        else if (totalPercentage <= 1.5f)
        {
            Title.text = beginner;
        }

        SocialPoints.text = social + "/" + socialTotal;
        EconomyPoints.text = economy + "/" + economyTotal;
        EcologyPoints.text = ecology + "/" + ecologyTotal;

        if (social > socialTotal)
        {
            SocialPoints.text = socialTotal + "/" + socialTotal;
        }
        
        if (economy > economyTotal)
        {
            EconomyPoints.text = economyTotal + "/" + economyTotal;
        }
        
        if (ecology > ecologyTotal)
        {
            EcologyPoints.text = ecologyTotal + "/" + ecologyTotal;
        }
        
    }

    void SetGraphFill()
    {
        SocialGraph.fillAmount = socialPercentage;
        EcologyGraph.fillAmount = ecologyPercentage;
        EconomyGraph.fillAmount = economyPercentage;
    }

}
