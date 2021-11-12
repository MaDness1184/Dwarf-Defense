using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Header("Delays(seconds)")]
    int currentSceneIndex; // the index of the current scene relational to the Build order
    public float startDelay = 6f; // the delay in seconds of the first splash screen to the start screen

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // grabbing the build index of whatever scene is currently loaded
        if (currentSceneIndex <= 0) // if the current scene is the Splash/Loading scene immediately run LoadStartCo()
        {
            StartCoroutine(LoadStartCo());
        }
    }

    private IEnumerator LoadStartCo() // a coroutine that delays the transition from the loading screen to the start screen
    {
        yield return new WaitForSeconds(startDelay); // wait startDelay seconds
        LoadNextScene();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen"); // Load the next scene in the build index
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex); // Load the next scene in the build index
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1); // Load the next scene in the build index
    }

    public void LoadOptionsMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Options Screen"); // Load the next scene in the build index
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
