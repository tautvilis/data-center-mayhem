using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerActivation : MonoBehaviour
{
    public GameObject FixIcon;

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Enter");
        if(other.tag == "Player"){
            FixIcon.SetActive(true);
        }   
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            FixIcon.SetActive(false);
        }
    }
}
