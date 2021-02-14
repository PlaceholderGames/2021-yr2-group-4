using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitioner : MonoBehaviour
{
    public bool EndLevel = false;
    public Animator transition;
    public float transitionTime = 2;


    public void OnTriggerEnter()
    {
        if (EndLevel = true)
        {
            LoadNextLevel();
        }
        else
        {
            //Play level start animations.
        }
    }



    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex + 1);
    }
}
