using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaMachine : MonoBehaviour
{
    public GameObject BrewIcon;
    private GameObject Player;
    private bool IsNear = false;

    private float speedBoostDuration = 5;
    private float speedBoost = 5;
    private float normalSpeed = 8;

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Enter");
        if(other.tag == "Player"){
            BrewIcon.SetActive(true);
            IsNear = true;
        }   
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            BrewIcon.SetActive(false);
            IsNear = false;
        }
    }

    void Update() 
    {
        if(IsNear && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("brew tea");
            Player = GameObject.Find("Player");
            ActiveSpeedBoost();
        }
    }

    void ActiveSpeedBoost()
    {
        StartCoroutine(SpeedBoostCooldown());
    }

    IEnumerator SpeedBoostCooldown()
    {
        Player.GetComponent<PlayerController>().Speed = speedBoost;
        yield return new WaitForSeconds(speedBoostDuration);
        Player.GetComponent<PlayerController>().Speed = normalSpeed;
    }
}
