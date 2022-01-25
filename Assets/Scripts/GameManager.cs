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
    public static bool arduinoInteract = false;
    [SerializeField] GameObject DialogueWindow;
    private GameObject Talk;
    private float dialogueTime = 3f;
    void Start()
    {
        DialogueWindow.SetActive(false);
        Talk = DialogueWindow.gameObject.transform.GetChild(0).gameObject;
        if (SceneManager.GetActiveScene().name == "Game1")
        {
            movementActive = false;
            StartCoroutine(startDialogue());
        }

        else if (SceneManager.GetActiveScene().name == "Game5")
        {
            movementActive = false;
            StartCoroutine(scene5Start());
        }else if (SceneManager.GetActiveScene().name == "Game6")
        {
            movementActive = false;
            StartCoroutine(scene6Start());
        }
        else if (SceneManager.GetActiveScene().name == "Game7")
        {
            movementActive = false;
            StartCoroutine(scene7Start());
        }
        else if (SceneManager.GetActiveScene().name == "Game8")
        {
            movementActive = false;
            StartCoroutine(scene8Start());
        }else if (SceneManager.GetActiveScene().name == "Game9")
        {
            movementActive = false;
            StartCoroutine(scene9Start());
        }
    }

    private void Update()
    {
        if (levelPass)
        {
            nextLevel();
        }

        if (arduinoInteract)
        {
            arduinoInteract = false;

            StartCoroutine(ArduinoInteraction());
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
        Talk.GetComponent<TextMeshPro>().text = "Nerede olduğumu ve ne yapacağımı bilmiyorum.";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Sanırım ileri gitmeliyim. Tek yol bu gibi gözüküyor.";
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.SetActive(false);
        movementActive = true;
        levelPassed = true;
    }

    IEnumerator scene5Start()
    {
        DialogueWindow.SetActive(true);
        Talk.GetComponent<TextMeshPro>().text = "Bir dakika bütün ışık nereye gitti?";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Bence bunu çözebilirim.";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Şimdi devam etme zamanı!";
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.SetActive(false);
        movementActive = true;
    }

    IEnumerator scene6Start()
    {
        DialogueWindow.SetActive(true);
        Talk.GetComponent<TextMeshPro>().text = "Evet, yine ışık yok. Burada bir anahtar var gibi. Sorun ne olabilir ki?";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Bence bunu çözebilirim.";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "İlerlemeye devam etmeliyim.";
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.SetActive(false);
        movementActive = true;
    }
    IEnumerator scene7Start()
    {
        DialogueWindow.SetActive(true);
        Talk.GetComponent<TextMeshPro>().text = "Evet, yine ışık yok. Burada bir anahtar var gibi. Sorun ne olabilir ki?";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Farklı bir yol denemeliyim.";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Acaba daha neler göreceğim.";
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.SetActive(false);
        movementActive = true;
    }
    IEnumerator scene8Start()
    {
        DialogueWindow.SetActive(true);
        Talk.GetComponent<TextMeshPro>().text = "Çözülecek başka bir problem daha mı?";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Bunu da çözmek imkansız olamaz.";
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.SetActive(false);
        movementActive = true;
    }
    IEnumerator scene9Start()
    {
        DialogueWindow.SetActive(true);
        Talk.GetComponent<TextMeshPro>().text = "Sonunda! Işıkla ilgili bir problem yok.";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Yerdeki şey de ne öyle?";
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.SetActive(false);
        movementActive = true;
    }

    public IEnumerator ArduinoInteraction()
    {
        movementActive = false;
        DialogueWindow.SetActive(true);
        Talk.GetComponent<TextMeshPro>().text = "Üzerinde Arduino yazıyor. Bu onun adı olmalı...";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Evet, yanında bilgi alabileceğim bir kaç kağıt var.";
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.SetActive(false);
        movementActive = true;
    }
}
