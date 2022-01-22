using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
    public GameObject interactionObjectHolder;
    void Start()
    {
        animatorPlayer = GetComponent<Animator>();
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        TextBubble = gameObject.transform.GetChild(0).gameObject;
        levelCondition = 0;
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
        if (levelCondition >= 2)
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
        TextBubble.SetActive(false);
        if (other.gameObject.name == "Cable")
        {
            interActionGuide.SetActive(true);
            TextBubble.gameObject.SetActive(true);
            TextBubble.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Bu sey de nedir boyle?";
        }
        if (other.gameObject.name == "Battery")
        {
            interActionGuide.SetActive(true);
        }
        if (other.gameObject.name == "Lamp")
        {
            interActionGuide.SetActive(true);
            TextBubble.gameObject.SetActive(true);
            TextBubble.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Bu sey de nedir boyle?";
        }

        if (other.gameObject.name == "Switch")
        {
            interActionGuide.SetActive(true);
        }

        if (other.gameObject.name == "Doc")
        {
            interActionGuide.SetActive(true);
            TextBubble.gameObject.SetActive(true);
            TextBubble.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Bu kağıtlar da ne böyle?";
        }
    }

    private void OnTriggerStay2D(Collider2D trig)
    {
        Debug.Log("staying");
        if (trig.gameObject.name == "Cable")
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.movementActive = false;
                infoDocPanel.transform.GetChild(0).gameObject.SetActive(true);
                infoDocPanel.SetActive(true);
                TextBubble.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Faydali bir seye benziyor. Bunu saklamaliyim.";
                trig.gameObject.SetActive(false);
                trig.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                levelCondition++;
            }
        }
        if (trig.gameObject.name == "Battery")
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.movementActive = false;
                infoDocPanel.transform.GetChild(1).gameObject.SetActive(true);
                infoDocPanel.SetActive(true);
                TextBubble.gameObject.SetActive(true);
                TextBubble.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Bu da ise yarar gibi gozukuyor";
                trig.gameObject.SetActive(false);
                trig.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                levelCondition++;
            }
        }
        if (trig.gameObject.name == "Lamp")
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.movementActive = false;
                infoDocPanel.transform.GetChild(2).gameObject.SetActive(true);
                infoDocPanel.SetActive(true);
                TextBubble.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Faydali bir seye benziyor. Bunu saklamaliyim.";
                trig.gameObject.SetActive(false);
                trig.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                levelCondition++;
            }
        }
        if (trig.gameObject.name == "Switch")
        {
            if (Input.GetKey(KeyCode.E)) 
            {
                GameManager.movementActive = false;
                infoDocPanel.transform.GetChild(3).gameObject.SetActive(true);
                infoDocPanel.SetActive(true);
                TextBubble.gameObject.SetActive(true);
                TextBubble.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Bu da ise yarar gibi gozukuyor";
                trig.gameObject.SetActive(false);
                trig.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                levelCondition++;
            }
        }

        if (trig.gameObject.name == "Doc")
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.movementActive = false;
                infoDocPanel.transform.GetChild(3).gameObject.SetActive(true);
                infoDocPanel.SetActive(true);
                TextBubble.gameObject.SetActive(true);
                TextBubble.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Bu da ise yarar gibi gozukuyor";
                trig.gameObject.SetActive(false);
                trig.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                levelCondition = 2;
            }
        }
        if (trig.gameObject.name == "BatteryInteractive")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                trig.gameObject.transform.SetParent(this.gameObject.transform);

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
