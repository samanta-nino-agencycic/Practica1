using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ScripDePrueba : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
   
    private Rigidbody2D rigidbody2;
    public float velocity = 4; // m/s
    private Vector2 moveDirection;

    void Start()
    {
        // GetComponent Sprite Renderer
        // GetCpmponent Rigibody2D
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2 = GetComponent<Rigidbody2D>();


    }
    private void FixedUpdate()
    {
        moveDirection.x = velocity * Input.GetAxis("Horizontal");
        moveDirection.y = rigidbody2.velocity.y;
        rigidbody2.velocity = moveDirection;


    }

    // Update is called once per frame
    void Update()
    {
        //Inputs 
        if (Input.GetKeyDown(KeyCode.A))
            spriteRenderer.flipX = true;

        if(Input.GetKeyDown(KeyCode.D))
            spriteRenderer.flipX = false;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            spriteRenderer.flipX = true;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            spriteRenderer.flipX = false;
    }
}
