using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (isPaused)
        {
            SceneManager.LoadScene("Pause Screen", LoadSceneMode.Additive);
            Time.timeScale = 0f;
        }
        else
        {
            SceneManager.UnloadSceneAsync("Pause Screen");
            Time.timeScale = 1f;
        }
    }
}
