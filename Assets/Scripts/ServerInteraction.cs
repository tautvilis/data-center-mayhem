using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerInteraction : MonoBehaviour
{
    public LayerMask myLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
         {
             Collider[] objectToDetect = Physics.OverlapSphere(transform.position, 20, myLayer);
             if (objectToDetect.Length > 0)
             {
                 if (objectToDetect[0].gameObject.tag == "Server")
                 {
                     Debug.Log("Ezz");
                 }
             }
         }
    }
}
