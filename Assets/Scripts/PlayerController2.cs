using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    private Animator animatorPlayer;
    [SerializeField] private float movementSpeed = 1f;
    private Rigidbody2D playerRB;
    private float lastPosition = 0;
    [SerializeField] private GameObject interActionGuide;
    private GameObject TextBubble;
    [SerializeField] private GameObject infoDocPanel;
    private GameManager managerGame;
    private int levelCondition = 0;
    public GameObject interactiobObjectHolder;
    [SerializeField] GameObject playerHolder;
    private GameObject ourBattery;
    [SerializeField] private GameObject DarkPanel, lamp, lamp2;
    [SerializeField] private GameObject switchOpen, switchClosed;
    [SerializeField] private GameObject switchOpen2, switchClosed2;
    private bool lightIsOn = false;
    [SerializeField] private GameObject Doc;
    void Start()
    {
        
        animatorPlayer = GetComponent<Animator>();
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        TextBubble = gameObject.transform.GetChild(0).gameObject;
        levelCondition = 0;
        if (SceneManager.GetActiveScene().name == "Game5" )
        {
            levelCondition = 1;
            GetComponent<PlayerController>().enabled = false;
            Destroy(GetComponent<PlayerController>());
        }

        else if (SceneManager.GetActiveScene().name == "Game6")
        {
            levelCondition = 1;
        }else if (SceneManager.GetActiveScene().name == "Game7")
        {
            levelCondition = 0;
        }else if (SceneManager.GetActiveScene().name == "Game8")
        {
            levelCondition = 0;
        }else if (SceneManager.GetActiveScene().name == "Game9")
        {
            levelCondition = 1;
        }
        
        
    }

    void Update()
    {
        float dirX = Input.GetAxis ("Horizontal") ;
        lastPosition = transform.position.x;
        Debug.Log(levelCondition);

        if (transform.position.x >= 40 && transform.position.x <=1970 && GameManager.movementActive)
        {
            if (dirX !=0)
            {
                if (dirX >0)
                {
                    animatorPlayer.SetBool("Left", false);
                    animatorPlayer.SetBool("Right", true);
                    animatorPlayer.SetBool("RightRun", true);
                }
                else
                {
                    animatorPlayer.SetBool("Right", false);
                    animatorPlayer.SetBool("Left", true);
                    animatorPlayer.SetBool("LeftRun", true);
                }
            }
            else
            {
                animatorPlayer.SetBool("RightRun", false);
                animatorPlayer.SetBool("LeftRun", false);

            }
            playerRB.velocity= new Vector2(dirX * movementSpeed, 0);
        }
        else
        {
            playerRB.velocity = Vector2.zero;
        }

        if (PropTrigger.textBubble)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        if (infoDocPanel.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < 5; i++)
            {
                infoDocPanel.transform.GetChild(i).gameObject.SetActive(false);
            }
            infoDocPanel.SetActive(false);
            GameManager.movementActive = true;

        }
        if (levelCondition >= 2 && SceneManager.GetActiveScene().name != "Game8")
        {
            GameManager.levelPassed = true;
            lightIsOn = true;
        }else if (levelCondition >=3)
        {
            GameManager.levelPassed = true;
        }else if (levelCondition >= 2)
        {
            lightIsOn = true;
        }
        if (lightIsOn)
        {
            lamp.SetActive(false);
            lamp2.SetActive(true);
            DarkPanel.SetActive(false);
        }
        
        if (levelCondition >= 2 && SceneManager.GetActiveScene().name != "Game9")
        {
            GameManager.levelPassed = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "RightSide")
        {
            GameManager.levelPass = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Battery")
        {
            interActionGuide.SetActive(true);
        }

        if (other.gameObject.name == "BatteryLocation")
        {
            interActionGuide.SetActive(true);            
        }

        if (other.gameObject.name == "Switch")
        {
            interActionGuide.SetActive(true);
        }

        if (other.gameObject.name == "Switch2")
        {
            interActionGuide.SetActive(true);
        }

        if (other.gameObject.name == "Doc")
        {
            interActionGuide.SetActive(true);
        }

        if (other.gameObject.name == "Arduino")
        {
            GameManager.arduinoInteract = true;
        }
    }

    private void OnTriggerStay2D(Collider2D trig)
    {
        if (trig.gameObject.name == "Battery")
        {
            ourBattery = trig.gameObject;
            if (Input.GetKey(KeyCode.E))
            {
                trig.gameObject.transform.SetParent(playerHolder.transform);
                trig.gameObject.transform.position = playerHolder.gameObject.transform.position;
                trig.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        if (trig.gameObject.name == "BatteryLocation")
        {
            if (Input.GetKey(KeyCode.E))
            {
                ourBattery.transform.parent = null;
                ourBattery.transform.position = trig.transform.position;
                trig.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                levelCondition +=1;
            }
        }

        if (trig.gameObject.name == "Switch")
        {
            if (Input.GetKey(KeyCode.E))
            {
                switchOpen.SetActive(false);
                switchClosed.SetActive(true);
                trig.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                levelCondition +=1;
            }
        }

        if (trig.gameObject.name == "Switch2")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Doc.gameObject.SetActive(true);
                switchOpen2.SetActive(true);
                switchClosed2.SetActive(false);
                trig.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                levelCondition +=1;
            }
        }

        if (trig.gameObject.name == "Doc")
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.movementActive = false;
                infoDocPanel.transform.GetChild(5).gameObject.SetActive(true);
                infoDocPanel.SetActive(true);
                TextBubble.gameObject.SetActive(true);
                TextBubble.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Bu da ise yarar gibi gozukuyor";
                trig.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                trig.gameObject.SetActive(false);
                levelCondition +=1;
            }
        }

        if (trig.gameObject.name == "Arduino")
        {
            if (Input.GetKey(KeyCode.E))
            {
                TextBubble.gameObject.SetActive(true);
                TextBubble.transform.GetChild(0).GetComponent<TextMeshPro>().text = "";
                trig.gameObject.SetActive(false);
                trig.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                levelCondition++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null)
        {
            interActionGuide.SetActive(false);
        }  
    }
}
