using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lideverything : MonoBehaviour
{
    public Text inputtext;
    // Start is called before the first frame update
    void Awake()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     

        void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "blueball")
        {   
            Physics.IgnoreCollision(collision.collider.gameObject.GetComponent<Collider>(), GetComponent<Collider>(),true);   
            Color c=gameObject.GetComponent<Renderer>().material.color;
            c.a=0.2f;
            gameObject.GetComponent<Renderer>().material.color=c;
            
        }
        if (collision.collider.gameObject.name == "greenball")
        {   
            Color d=gameObject.GetComponent<Renderer>().material.color;
            d.a=0.9f;
            gameObject.GetComponent<Renderer>().material.color=d;
            collision.collider.gameObject.GetComponent<respawn>().Respawn();
            StartCoroutine(temptrans(collision.collider.gameObject));
            
        }
    }
    IEnumerator temptrans(GameObject go){
           
            
            yield return new WaitForSeconds(2.25f);
            Destroy(go); 
            StopCoroutine(temptrans(go));
            
            yield return null;
    }
}
