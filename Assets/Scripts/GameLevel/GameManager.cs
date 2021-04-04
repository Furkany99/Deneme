using System.Diagnostics.Contracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject BaslaImage;

    [SerializeField]
    private Text soruTxt,birinciSonucTxt,ikinciSonucTxt,ucuncuSonucTxt;

    [SerializeField]
    private Text dogruAdetText,yanlisAdetText,toplamPuanText;
    
    [SerializeField]
    private GameObject dogruImage,yanlisImage;
    string hangiOyun;
    
    int birinciCarpan;
    int ikinciCarpan;

    int dogruSonuc;
    int birinciYanlisSonuc;
    int ikinciYanlisSonuc;
    
    public int dogruAdet,yanlisAdet,toplamPuan;

    PlayerManager playerManager;

    private void Awake() 
    {
        playerManager=Object.FindObjectOfType<PlayerManager>();
    }

    void Start()
    {
        dogruAdet=0;
        yanlisAdet=0;
        toplamPuan=0;

        dogruImage.GetComponent<RectTransform>().localScale=Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale=Vector3.zero;

        if(PlayerPrefs.HasKey("hangiOyun"))
        {
            hangiOyun= PlayerPrefs.GetString("hangiOyun");
           
        }

        StartCoroutine(baslaYaziRoutine());
       
        
    }

    IEnumerator baslaYaziRoutine()
    {
        BaslaImage.GetComponent<RectTransform>().DOScale(1.3f,0.5f);
        yield return new WaitForSeconds(0.6f);
        BaslaImage.GetComponent<RectTransform>().DOScale(0f,0.5f).SetEase(Ease.InBack);
        BaslaImage.GetComponent<CanvasGroup>().DOFade(0f,1f);
        yield return new WaitForSeconds(0.6f);

        OyunaBasla();
    }

    void OyunaBasla()
    {
        playerManager.rotaDegissinMi=true;
        SoruyuYazdir();
    }

    void BirinciCarpaniAyarla()
    {
        switch (hangiOyun)
        {   
            case "iki":
            birinciCarpan=2;
            break;

            case "üç":
            birinciCarpan=3;
            break;

            case "dört":
            birinciCarpan=4;
            break;

            case "beş":
            birinciCarpan=5;
            break;

            case "altı":
            birinciCarpan=6;
            break;

            case "yedi":
            birinciCarpan=7;
            break;

            case "sekiz":
            birinciCarpan=8;
            break;

            case "dokuz":
            birinciCarpan=9;
            break;

            case "on":
            birinciCarpan=10;
            break;

            case "karışık":
            birinciCarpan=Random.Range(2,11);
            break;
            
            
        }
       

    }

    void SoruyuYazdir()
    {
        BirinciCarpaniAyarla();

        ikinciCarpan=Random.Range(2,11);

        int rastgeleDeger=Random.Range(1,100);

        if(rastgeleDeger<=50)
        {
            soruTxt.text=birinciCarpan.ToString() + " x " + ikinciCarpan.ToString();
        }
        else 
        {
            soruTxt.text=ikinciCarpan.ToString() + " x " + birinciCarpan.ToString();
        }
        dogruSonuc=birinciCarpan*ikinciCarpan;
        SonuclariYazdir();
    }

    void SonuclariYazdir()
    {

        birinciYanlisSonuc=dogruSonuc+Random.Range(2,10);
        if(dogruSonuc<10)
        {
            ikinciYanlisSonuc=dogruSonuc-Random.Range(2,8);
        }
        else
        {
            ikinciYanlisSonuc=Mathf.Abs(dogruSonuc-Random.Range(1,5));
        }

        int rastgeleDeger=Random.Range(1,100);

        if(rastgeleDeger<=33)
        {
            birinciSonucTxt.text=dogruSonuc.ToString();
            ikinciSonucTxt.text=birinciYanlisSonuc.ToString();
            ucuncuSonucTxt.text=ikinciYanlisSonuc.ToString();

        }else if(rastgeleDeger<=66)
        {
            ikinciSonucTxt.text=dogruSonuc.ToString();
            birinciSonucTxt.text=birinciYanlisSonuc.ToString();
            ucuncuSonucTxt.text=ikinciYanlisSonuc.ToString();


        }else
        {
            ucuncuSonucTxt.text=dogruSonuc.ToString();
            ikinciSonucTxt.text=birinciYanlisSonuc.ToString();
            birinciSonucTxt.text=ikinciYanlisSonuc.ToString();

        }
    }
    
    public void SonucuKontrolEt(int textSonucu)
    {

        dogruImage.GetComponent<RectTransform>().localScale=Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale=Vector3.zero;

        if(textSonucu==dogruSonuc)
        {
            dogruAdet++;
            toplamPuan+=20;
            dogruImage.GetComponent<RectTransform>().DOScale(1,0.1f);
        }else
        {
            yanlisAdet++;
            toplamPuan-=10;
            yanlisImage.GetComponent<RectTransform>().DOScale(1,0.1f);
        }

        dogruAdetText.text=dogruAdet.ToString()+ " DOĞRU";
        yanlisAdetText.text=yanlisAdet.ToString()+ " YANLIŞ";
        toplamPuanText.text=toplamPuan.ToString()+ " PUAN";


        SoruyuYazdir();

    }


}
