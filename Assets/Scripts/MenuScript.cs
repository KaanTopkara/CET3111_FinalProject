using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject OptionsMenu;
    public void startButton()
    {
        SceneManager.LoadScene("Game1");
    }

    public void optionsButton()
    {
        StartMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
