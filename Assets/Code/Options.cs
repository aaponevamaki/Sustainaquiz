using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    [SerializeField] private Toggle Hand;
    [SerializeField] private TextMeshProUGUI HandLabel;

    void Start()
    {
        if (PlayerPrefs.GetString("Hand") == "Left")
        {
            Hand.isOn = true;
        }
        else
        {
            Hand.isOn = false;
        }

        if (PlayerPrefs.GetString("Language") == "English")
        {
            HandLabel.text = "Left-handed";
        }
        else
        {
            HandLabel.text = "Vasenkätinen";
        }
    }

    public void HandChange()
    {
        if (PlayerPrefs.GetString("Hand") == "Left")
        {
            PlayerPrefs.SetString("Hand", "Right");
            Debug.Log("Set to right");
        }
        else
        {
            PlayerPrefs.SetString("Hand", "Left");
            Debug.Log("Set to left");
        }
        PlayerPrefs.Save();
    }

    public void OpenEdusta()
    {
        Application.OpenURL("https://projects.tuni.fi/edusta/");
    }

    public void OpenTiko()
    {
        Application.OpenURL("https://webpages.tuni.fi/22tiko/");
    }

    public void OpenSeventeenGoals()
    {
        Application.OpenURL("https://sdgs.un.org/goals");
    }

    public void OpenJoystickMobile()
    {
        Application.OpenURL("https://webpages.tuni.fi/22tiko1f/");
    }
}
