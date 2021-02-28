using UnityEngine;
using UnityEngine.SceneManagement;

public class F3DMainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;

    private GameObject activeMenu;

    private void Start()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);

        activeMenu = mainMenu;
    }

    public void PlayButton()
    {
        SceneManager.LoadSceneAsync("Demo");
    }

    public void CreditsButton()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);

        activeMenu = creditsMenu;
    }

    public void MMBackButton()
    {
        activeMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}

