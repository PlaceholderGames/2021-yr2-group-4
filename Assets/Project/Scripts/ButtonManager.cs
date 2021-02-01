using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    public Animator transition;
    public float transitionTime = 2;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    public void ButtonStart()
    {
        Time.timeScale = 1f;
        //LoadNextLevel();
        SceneManager.LoadScene("RyanTestLevel", LoadSceneMode.Single);
    }

    public void ButtonCredits()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenu.SetActive(false);
        
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex + 1);
    }
}