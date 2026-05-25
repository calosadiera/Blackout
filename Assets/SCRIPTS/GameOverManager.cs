using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu";
    public float delay = 3f;

    void Start()
    {
        Invoke("GoToMainMenu", delay);
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}