using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Rigidbody2D body;
    private Animator animator;
    
    public GameObject Circle;
    //public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        body.velocity = new Vector2(horizontalInput * Speed, verticalInput * Speed);
        transform.position = new Vector3(body.position.x, body.position.y, 1);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var gameObject = collision.gameObject;
        if (gameObject.tag == "Server")
        {
            for(int i = 0; i < gameObject.transform.childCount; i++)
            {
                
                var child = gameObject.transform.GetChild(i).gameObject;
                Debug.Log(child.tag);
                if(child.tag == "ServerFixIcon"){
                    child.SetActive(true);
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        var gameObject = collision.gameObject;
        if (gameObject.tag == "Server")
        {
            for(int i = 0; i < gameObject.transform.childCount; i++)
            {
                var child = gameObject.transform.GetChild(i).gameObject;
                if(child.tag == "ServerFixIcon"){
                    child.SetActive(false);
                }
            }
        }
    }

}

