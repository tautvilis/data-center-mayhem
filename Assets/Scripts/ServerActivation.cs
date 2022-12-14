using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerActivation : MonoBehaviour
{
    public GameObject FixIcon;
    public GameObject CameraManager;
    public GameObject _minigameManager;
    private bool IsNear = false;

    private void Awake() {

    } 
    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Enter");
        if(other.tag == "Player"){
            FixIcon.SetActive(true);
            IsNear = true;
        }   
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            FixIcon.SetActive(false);
            IsNear = false;
        }
    }

    void Update() 
    {
        if(IsNear && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Open minigame");
            CameraManager.GetComponent<CameraManager>().ChangeCamera(2);
            _minigameManager.GetComponent<MinigameManager>().Startminigame();

        }
    }
}
