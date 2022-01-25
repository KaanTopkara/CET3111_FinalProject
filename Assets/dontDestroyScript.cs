using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontDestroyScript : MonoBehaviour
{
   private void Awake()
   {
      if (SceneManager.GetActiveScene().name != "End")
      {
         DontDestroyOnLoad(this.gameObject);
      }
   }
}
