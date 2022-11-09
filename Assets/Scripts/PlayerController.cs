using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float Speed;
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

}

