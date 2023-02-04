using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayBasicGame()
    {
        SceneManager.LoadScene("Basics");
    }

    public void PlayBottleFlipGame()
    {
        SceneManager.LoadScene("BottleFlip");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
