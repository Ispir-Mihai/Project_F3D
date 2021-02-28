using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class F3DGameManager : MonoBehaviour
{
    public F3DCharacter player;
    public Text healthDisplay;

    private void Update()
    {
        if (healthDisplay)
            healthDisplay.text = player.Health.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
