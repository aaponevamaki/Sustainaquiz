using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image oldImage;
    public Sprite muteButton;
    public Sprite unmuteButton;

    public void ImageChange()
    {
        if (oldImage.sprite == muteButton)
        {
            oldImage.sprite = unmuteButton;
        }
        else
        {
            oldImage.sprite = muteButton;
        }
        
    }
}
