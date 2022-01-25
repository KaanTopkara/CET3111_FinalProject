using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject OptionsMenu;
    [SerializeField] private GameObject infoPanel,panel;
    public void startButton()
    {
        SceneManager.LoadScene("Game1");
    }

    public void tryAgainButton()
    {
        SceneManager.LoadScene("Start");
    }

    public void infoButton()
    {
        panel.SetActive(false);
        infoPanel.SetActive(true);
    }
    public void closeInfoButton()
    {
        panel.SetActive(true);
        infoPanel.SetActive(false);
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
