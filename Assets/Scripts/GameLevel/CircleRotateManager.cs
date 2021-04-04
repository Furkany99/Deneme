using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CircleRotateManager : MonoBehaviour
{
    string hangiSonuc;

    GameManager gameManager;

    private void Awake() 
    {
        gameManager=Object.FindObjectOfType<GameManager>();
        
    }

   private void OnTriggerEnter2D(Collider2D other) 
   {
       if(other.tag=="Mermi")
       {
          gameObject.transform.DORotate(transform.eulerAngles+Quaternion.AngleAxis(360,Vector3.forward).eulerAngles,0.5f);


        if(other.gameObject!=null)
           {
           Destroy(other.gameObject);
           }

        if(gameObject.name=="Sonuc1")
        {
            hangiSonuc=GameObject.Find("SolSonuc").GetComponent<Text>().text;
        }
        else if(gameObject.name=="Sonuc2")
        {
            hangiSonuc=GameObject.Find("OrtaSonuc").GetComponent<Text>().text;
        }else if(gameObject.name=="Sonuc3")
        {
            hangiSonuc=GameObject.Find("SağSonuc").GetComponent<Text>().text;
        }
        
        gameManager.SonucuKontrolEt(int.Parse(hangiSonuc));

       }
   }
}
