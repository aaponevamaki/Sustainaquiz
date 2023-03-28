using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    [SerializeField] string TargetScene;
    public void ChangeScene()
    {
        SceneManager.LoadScene(TargetScene);
    }
}
