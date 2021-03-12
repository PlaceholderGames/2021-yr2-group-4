using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject OnScreenUI;
    private bool isPaused;
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
                OnScreenUI.SetActive(false);
                Time.timeScale = 0f;
            }
        }
    }
    public void ButtonStart()
    {
        Time.timeScale = 1f;
        LoadNextLevel();
        //SceneManager.LoadScene("RyanTestLevel", LoadSceneMode.Single);
    }

    public void ButtonCredits()
    {
        
        Time.timeScale = 1f;
        StartCoroutine(LevelTransition(1));
        //SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    public void ButtonMainMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(LevelTransition(2));
        //SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ButtonQuit()
    {
        StartCoroutine(LevelTransition(0));
        Application.Quit();
    }

    public void ResumeGame()
    {
        
        isPaused = false;
        pauseMenu.SetActive(false);
        OnScreenUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void LoadNextLevel()
    {
        //pauseMenu.SetActive(false);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LevelTransition(int LevelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex + 1);
    }
}