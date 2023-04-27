using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image oldImage;
    public Sprite newSprite;
    public Sprite oldSprite;

    public void ImageChange()
    {
        if (oldImage.sprite == newSprite)
        {
            oldImage.sprite = oldSprite;
        }
        else
        {
            oldImage.sprite = newSprite;
        }
        
    }
}
