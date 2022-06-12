using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject optionsScreen, pauseScreen;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
    }

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
        SceneManager.LoadScene("Main Menu 2", LoadSceneMode.Single);
    }
}
