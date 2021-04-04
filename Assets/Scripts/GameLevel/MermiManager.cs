using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MermiManager : MonoBehaviour
{
    
    float mermiHizi=20f;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Mermi")
        {
            Debug.Log(this.gameObject.name);
        }
        
    }




    void Start()
    {
        if(this.gameObject!=null)
        {
            Destroy(this.gameObject, 3f);
        }
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.up*Time.deltaTime*mermiHizi);

        
        
    }
}
