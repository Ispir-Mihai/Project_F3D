using UnityEngine;
using UnityEngine.SceneManagement;

public class F3DPauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            } else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void ResumeButton()
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void BackToMMButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("StartMenu");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}

