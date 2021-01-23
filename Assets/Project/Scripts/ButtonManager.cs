using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
     /*void Start()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene("RyanTestLevel", LoadSceneMode.Additive);
    }  */
    public void ButtonStart()
    {
        SceneManager.LoadScene("RyanTestLevel", LoadSceneMode.Single);
    }

    public void ButtonCredits()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}