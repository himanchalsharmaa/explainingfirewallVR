using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class move_inspace : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update(); 
        Vector2 leftright=OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 destination1 = new Vector3(transform.position.x+leftright.x,transform.position.y,transform.position.z+leftright.y);
        transform.position=Vector3.Lerp(transform.position, destination1, 0.35f);
        Vector2 updown=OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        Vector3 destination2 = new Vector3(transform.position.x,transform.position.y+updown.y,transform.position.z);
        transform.position=Vector3.Lerp(transform.position, destination2, 0.1f);
        transform.Rotate(0,updown.x,0,Space.World);
    }
}
