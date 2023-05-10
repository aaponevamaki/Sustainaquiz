using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public void button_animation()
    {
        GetComponent<Animation>().Play("Button_Animation");
    }
}
