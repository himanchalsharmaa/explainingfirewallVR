using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class respawn : MonoBehaviour
{
    private Vector3 initial_pos;
    private Rigidbody rb;
    private GameObject ball_copy;
    private List<GameObject> listobj=new List<GameObject>();
    private Material material;
    public Text itext;
    // Start is called before the first frame update
    void Awake()
    {
        initial_pos=transform.position;
        rb=transform.GetComponent<Rigidbody>();
        material = GetComponent<Renderer>().material;
        //var m_Material = GetComponent<Renderer>().material;
        ball_copy=gameObject;
        int cdecide= Random.Range(0, 10);
        if(cdecide%2==0){
            gameObject.name="blueball";
            ball_copy.name="blueball";
            material.SetColor("_Color", Color.blue);
        }
        else{
            gameObject.name="greenball";
            ball_copy.name="greenball";
            material.SetColor("_Color", Color.green);
        }
        StartCoroutine(destall(gameObject));
        
    }

    // Update is called once per frame
    void Update()
    {

    }

      void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {   
            StartCoroutine(dest(gameObject));
            Respawn();
        }

        if (collision.gameObject.tag == "ground1")
        {   
            Destroy(gameObject);
        }
    }
    IEnumerator dest(GameObject go){
        yield return new WaitForSeconds(5);
        Destroy(go);
    }
    public void Respawn(){
        GameObject gameobj=Instantiate(ball_copy,initial_pos,Quaternion.identity);
       
    }
    IEnumerator destall(GameObject gii){
        yield return new WaitForSeconds(15);
        Destroy(gii);
        StopCoroutine(destall(gii));
    }
}
