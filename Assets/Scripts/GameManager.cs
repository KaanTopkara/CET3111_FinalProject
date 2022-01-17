using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool movementActive = true;
    public static bool levelPass = false;
    public static bool levelPassed = false;
    [SerializeField] GameObject DialogueWindow;
    private GameObject Talk;
    [SerializeField] private float dialogueTime = 1f;
    void Start()
    {
        DialogueWindow.SetActive(false);
        Talk = DialogueWindow.gameObject.transform.GetChild(0).gameObject;
        if (SceneManager.GetActiveScene().name == "Game1")
        {
            movementActive = false;
            StartCoroutine(startDialogue());
        }
    }

    private void Update()
    {
        if (levelPass)
        {
            nextLevel();
        }
    }

    public void nextLevel()
    {
        if (movementActive && levelPassed)
        {
            levelPassed = false;
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
            levelPass = false;
        }
    }

    IEnumerator startDialogue()
    {
        DialogueWindow.SetActive(true);
        Talk.GetComponent<TextMeshPro>().text = "Buraya nasıl geldim?";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Nerede oldugumu ve ne yapacagimi bilmiyorum?";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Sanirim ileri gitmeliyim. Tek yol bu gibi gözüküyor.";
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.SetActive(false);
        movementActive = true;
        levelPassed = true;
    }
    
}
