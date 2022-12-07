using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : MonoBehaviour
{    
    private GameObject Fire;

    void Awake() {
        Fire = gameObject.transform.GetChild(0).gameObject;
        Fire.GetComponent<SpriteRenderer>().enabled = false;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnableServer(bool enable) {
        // gameObject.SetActive(enable);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void OnFire(bool fire) {
        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
