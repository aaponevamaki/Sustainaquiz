using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguageSettings : MonoBehaviour
{

    [SerializeField] public Toggle Language;
    [SerializeField] public TextMeshProUGUI playButtonText;
    [SerializeField] public TextMeshProUGUI optionsButtonText;
    [SerializeField] public TextMeshProUGUI statsButtonText;

    void Start()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            if (PlayerPrefs.GetString("Language") == "English")
            {
                Language.isOn = true;
                playButtonText.text = "Play";
                optionsButtonText.text = "Extra";
                statsButtonText.text = "Stats";
            }
            else
            {
                Language.isOn = false;
                playButtonText.text = "Pelaa";
                optionsButtonText.text = "Lisää";
                statsButtonText.text = "Tilastot";
            }
        }
        else
        {
            PlayerPrefs.SetString("Language", "Finnish");
            playButtonText.text = "Pelaa";
            optionsButtonText.text = "Lisää";
            statsButtonText.text = "Tilastot";
        }
    }

    void Update()
    {
        if (Language.isOn)
        {
            playButtonText.text = "Play";
            optionsButtonText.text = "Extra";
            statsButtonText.text = "Stats";
        }
        else
        {
            playButtonText.text = "Pelaa";
            optionsButtonText.text = "Lisää";
            statsButtonText.text = "Tilastot";
        }
    }
}
