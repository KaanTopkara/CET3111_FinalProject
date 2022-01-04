using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool movementActive = true;
    private bool levelPassed = false;
    [SerializeField] GameObject DialogueWindow;
    [SerializeField] private float dialogueTime = 1f;
    void Start()
    {
        DialogueWindow.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Game1")
        {
            movementActive = false;
            StartCoroutine(startDialogue());
        }
    }

    public void nextLevel()
    {
        Debug.Log("Iamcalled");
        if (movementActive && levelPassed)
        {
            Debug.Log("ImcalledToo");
            levelPassed = false;
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator startDialogue()
    {
        DialogueWindow.SetActive(true);
        DialogueWindow.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.transform.GetChild(0).gameObject.SetActive(false);
        DialogueWindow.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.transform.GetChild(1).gameObject.SetActive(false);
        DialogueWindow.transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.transform.GetChild(2).gameObject.SetActive(false);
        DialogueWindow.SetActive(false);
        movementActive = true;
        levelPassed = true;
    }
}
