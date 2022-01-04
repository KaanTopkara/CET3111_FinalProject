using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animatorPlayer;
    [SerializeField] private float movementSpeed = 1f;
    private Rigidbody2D playerRB;
    private float lastPosition = 0;
    [SerializeField] private GameObject interActionGuide;
    private GameManager managerGame;
    void Start()
    {
        animatorPlayer = GetComponent<Animator>();
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float dirX = Input.GetAxis ("Horizontal") ;
        lastPosition = transform.position.x;

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

        if (PropTrigger.textBubble)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collisionHappend");
        if (collision.gameObject.name == "RightSide" )
        {
           managerGame.nextLevel();
        }

        if (collision.gameObject.name == "Cable")
        {
            
        }
        if (collision.gameObject.name == "Battery")
        {
            
        }
        if (collision.gameObject.name == "Lamp")
        {
            
        }
        if (collision.gameObject.name == "Switch")
        {
            
        }
    }
}
