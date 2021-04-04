using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip butonClick;

    [SerializeField]
    private GameObject sesPaneli;
  
    bool sesPaneliAcikMi;
    void Start()
    {
        sesPaneliAcikMi=false;

        sesPaneli.GetComponent<RectTransform>().localPosition=new Vector3(0,132,0);

        menuPanel.GetComponent<CanvasGroup>().DOFade(1,1f);
        menuPanel.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.OutBack);
        
    }

    public void DigerEkran()
    {
        if(PlayerPrefs.GetInt("sesDurumu")==1)
        {
            audioSource.PlayOneShot(butonClick);
        }
        
        SceneManager.LoadScene("MenuLevel2");
    }

    public void Ayarlar()
    {

        if(PlayerPrefs.GetInt("sesDurumu")==1)
        {
            audioSource.PlayOneShot(butonClick);
        }
       

        if(!sesPaneliAcikMi)
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveY(9,0.5f);
            sesPaneliAcikMi=true;
        }else
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveY(132,0.5f);
            sesPaneliAcikMi=false;
        }

    }

    public void Cikis()
    {
        if(PlayerPrefs.GetInt("sesDurumu")==1)
        {
            audioSource.PlayOneShot(butonClick);
        }
         
        Application.Quit();
    }
 
  
}
