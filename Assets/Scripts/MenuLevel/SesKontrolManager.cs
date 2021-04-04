using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrolManager : MonoBehaviour
{
    private void Start() 
    {
        SesAc();  
    }
   public void SesAc()
   {
       PlayerPrefs.SetInt("sesDurumu", 1);
   }

   public void SesKapat()
   {
       PlayerPrefs.SetInt("sesDurumu",0);
   }
}
