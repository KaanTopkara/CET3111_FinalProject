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
        Talk.GetComponent<TextMeshPro>().text = "Buraya nas??l geldim?";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Nerede oldu??umu ve ne yapaca????m?? bilmiyorum.";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "San??r??m ileri gitmeliyim. Tek yol bu gibi g??z??k??yor.";
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.SetActive(false);
        movementActive = true;
        levelPassed = true;
    }

    IEnumerator scene5Start()
    {
        DialogueWindow.SetActive(true);
        Talk.GetComponent<TextMeshPro>().text = "Bir dakika b??t??n ??????k nereye gitti?";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Bence bunu ????zebilirim.";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "??imdi devam etme zaman??!";
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.SetActive(false);
        movementActive = true;
    }

    IEnumerator scene6Start()
    {
        DialogueWindow.SetActive(true);
        Talk.GetComponent<TextMeshPro>().text = "Evet, yine ??????k yok. Burada bir anahtar var gibi. Sorun ne olabilir ki?";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Bence bunu ????zebilirim.";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "??lerlemeye devam etmeliyim.";
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.SetActive(false);
        movementActive = true;
    }
    IEnumerator scene7Start()
    {
        DialogueWindow.SetActive(true);
        Talk.GetComponent<TextMeshPro>().text = "Evet, yine ??????k yok. Burada bir anahtar var gibi. Sorun ne olabilir ki?";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Farkl?? bir yol denemeliyim.";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Acaba daha neler g??rece??im.";
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.SetActive(false);
        movementActive = true;
    }
    IEnumerator scene8Start()
    {
        DialogueWindow.SetActive(true);
        Talk.GetComponent<TextMeshPro>().text = "????z??lecek ba??ka bir problem daha m???";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Bunu da ????zmek imkans??z olamaz.";
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.SetActive(false);
        movementActive = true;
    }
    IEnumerator scene9Start()
    {
        DialogueWindow.SetActive(true);
        Talk.GetComponent<TextMeshPro>().text = "Sonunda! I????kla ilgili bir problem yok.";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Yerdeki ??ey de ne ??yle?";
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.SetActive(false);
        movementActive = true;
    }

    public IEnumerator ArduinoInteraction()
    {
        movementActive = false;
        DialogueWindow.SetActive(true);
        Talk.GetComponent<TextMeshPro>().text = "??zerinde Arduino yaz??yor. Bu onun ad?? olmal??...";
        yield return new WaitForSeconds(dialogueTime);
        Talk.GetComponent<TextMeshPro>().text = "Evet, yan??nda bilgi alabilece??im bir ka?? ka????t var.";
        yield return new WaitForSeconds(dialogueTime);
        DialogueWindow.SetActive(false);
        movementActive = true;
    }
}
