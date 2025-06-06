using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class ScripDePrueba : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2;
    private Animator  animator; // Componente Animstor (aparecera en gris hata que realmente le pongamos el componente) 

    private Vector3 rayOffsetCirclePosition;
    public float velocity = 4f; // Velocidad maxima
    
    public float acceleration = 10f; // Aceleración
    public float deceleration = 15f; // Desaceleración
    public float rayCircleRadius = 1f; // colision para detectar el suelo
    public float jumpForce = 5f; // fuerza del salto 
    public LayerMask ground;

    private Vector2 moveDirection;
    private Vector2 jumpForceVector;
    private Vector3 rayCirclePosition;
    private float horizontal;
    private bool isMoving = false; 
    private bool flipDirection  = false;

    void Start()
    {
        animator = GetComponent<Animator>(); //traer componente animator
        spriteRenderer = GetComponent<SpriteRenderer>(); // traer componente Sprite Renderer
        rigidbody2 = GetComponent<Rigidbody2D>(); // traer componente Rigibody2D

    }
    private void FixedUpdate()
    {
        if (horizontal != 0)
        {
            float targetSpeed = horizontal * velocity;
            float speedDiff = targetSpeed - rigidbody2.velocity.x;
            float accelerationRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;
            rigidbody2.AddForce(Vector2.right * speedDiff * accelerationRate, ForceMode2D.Force);


        }
        else
        {
            rigidbody2.velocity = new Vector2(Mathf.Lerp(rigidbody2.velocity.x, 0, deceleration * Time.fixedDeltaTime), rigidbody2.velocity.y);
        }

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // Usamos raw para mejorar el controlador

        animator.SetFloat("speed", horizontal);

        isMoving = horizontal < 0;

        if (isMoving)
        {
            flipDirection = horizontal < 0;
            spriteRenderer.flipX = flipDirection;
        }
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    } 
    public bool IsGrounded()
    {
        rayCirclePosition = transform.position + rayOffsetCirclePosition;
        return Physics2D.OverlapCircle(rayCirclePosition, rayCircleRadius, ground);
         
    }

    private void Jump()
    {
        rigidbody2.velocity = new Vector2(rigidbody2.velocity.x, jumpForce);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        rayCirclePosition = transform.position + rayOffsetCirclePosition;
        Gizmos.DrawWireSphere(rayCirclePosition, rayCircleRadius);
    }
}
