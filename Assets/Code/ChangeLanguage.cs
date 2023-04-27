using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLanguage : MonoBehaviour
{
    public void ChangeLang(bool change)
    {
        if (change)
        {
            PlayerPrefs.SetString("Language", "English");
        }
        else
        {
            PlayerPrefs.SetString("Language", "Finnish");
        }
        PlayerPrefs.Save();
    }
}
