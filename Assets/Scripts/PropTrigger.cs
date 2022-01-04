using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropTrigger : MonoBehaviour
{
    [SerializeField] private GameObject interactionGuide;
    public static bool textBubble = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            interactionGuide.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                textBubble = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactionGuide.SetActive(false);
    }
}
