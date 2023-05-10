using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{   
    private int screenHeight;
    private int screenWidth;
    private Rect safe;

    void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        safe = Screen.safeArea;
    }
}
