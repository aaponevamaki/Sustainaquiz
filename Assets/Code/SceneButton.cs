using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    [SerializeField] string TargetScene;

    public Animator transition;

    IEnumerator LoadScene()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(TargetScene);
    }
}
