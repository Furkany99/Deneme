using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class AltMenuManager : MonoBehaviour
{

    [SerializeField]
    private GameObject altmenuPanel;
     
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip butonClick;

    
    
    void Start()
    {
        altmenuPanel.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.OutBack);
        altmenuPanel.GetComponent<CanvasGroup>().DOFade(1,1f);
    }

    public void HangiOyunAcilsin(string HangiOyun)
    {
         if(PlayerPrefs.GetInt("sesDurumu")==1)
        {
            audioSource.PlayOneShot(butonClick);
        }
        PlayerPrefs.SetString("hangiOyun",HangiOyun);
        SceneManager.LoadScene("GameLevel");
    }

    public void GeriDon()
    {
         if(PlayerPrefs.GetInt("sesDurumu")==1)
        {
            audioSource.PlayOneShot(butonClick);
        }
        
        SceneManager.LoadScene("MenuLevel1");

    }

    
}
