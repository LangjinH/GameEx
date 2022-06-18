using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject optionsScreen, pauseScreen;
    public void UnPause()
    {
        PauseControl.isPaused = false;
        SceneManager.UnloadSceneAsync("Pause Screen");
        Time.timeScale = 1f;
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void closeOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void QuitToMain()
    {
        PauseControl.isPaused = false;
        SceneManager.LoadScene("Main Menu 2", LoadSceneMode.Single);
    }
}
