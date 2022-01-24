using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyScript : MonoBehaviour
{
   private void Awake()
   {
      DontDestroyOnLoad(this.gameObject);
   }
}
