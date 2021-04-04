using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager: MonoBehaviour
{
    
    [SerializeField]
    private Transform silah;

    [SerializeField]
    private GameObject[] mermiPrefab;

    [SerializeField]
    private Transform mermiYeri;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip topSesi;

    float aci;

    float donusHizi=5f;

    float ikiMermiArasi=200f;

    float sonrakiAtis;

    public bool rotaDegissinMi;


    private void Start() 
    {   
        rotaDegissinMi=false;
        
    }
   
    void Update()
    {
        if(rotaDegissinMi)
        {
            RotateDegistir();
        }
       
    }

    void RotateDegistir()
    {
        Vector2 direction =Camera.main.ScreenToWorldPoint(Input.mousePosition)-silah.transform.position;
        aci=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg-90f;

        if(aci<85 && aci>-85)
        {
            Quaternion rotation=Quaternion.AngleAxis(aci,Vector3.forward);
            silah.transform.rotation=Quaternion.Slerp(silah.transform.rotation,rotation,donusHizi*Time.deltaTime);
        }


        

        if(Input.GetMouseButtonUp(0))
        {
            

            if(Time.time>sonrakiAtis)
            {
                sonrakiAtis=Time.time + ikiMermiArasi / 1000;
                MermiAt();

            }
           
        }

       

    }

    void MermiAt()
    {
         if(PlayerPrefs.GetInt("sesDurumu")==1)
        {
              audioSource.PlayOneShot(topSesi);
        }
      
        GameObject mermi=Instantiate(mermiPrefab[Random.Range(0,mermiPrefab.Length)],mermiYeri.position,mermiYeri.rotation) as GameObject;

    }
}
