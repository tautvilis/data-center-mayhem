using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    // Start is called before the first frame update

    public void ChangeCamera(int camera) {
        if(camera == 1) {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }else {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
    }
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
