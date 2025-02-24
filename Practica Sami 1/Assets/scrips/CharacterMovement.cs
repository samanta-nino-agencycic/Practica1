using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class public class ScripDePrueba : MonoBehaviour
 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    public Vector3 rayOffsetCirclePosition;
    public float moveSpeed = 4f; // Velocidad máxima
    public float acceleration = 10f; // Aceleración para suavizar el movimiento
    public float deceleration = 15f; // Desaceleración cuando no hay input
    public float rayCircleRadius = 1f; // Para detectar suelo
    public float jumpForce = 5f;
    public LayerMask ground;

    private Vector2 moveDirection;
    private Vector2 jumpForceVector;
    private Vector3 rayCirclePosition;
    private float horizontal;
    private bool isMoving = false;
    private bool flipDirection = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (horizontal != 0)
        {
            float targetSpeed = horizontal * moveSpeed;
            float speedDiff = targetSpeed - rb.velocity.x;
            float accelerationRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;

            // Aplicamos fuerza en la dirección del movimiento
            rb.AddForce(Vector2.right * speedDiff * accelerationRate, ForceMode2D.Force);
        }
        else
        {
            // Si no se mueve, reducimos la velocidad suavemente para evitar deslizamiento
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, deceleration * Time.fixedDeltaTime), rb.velocity.y);
        }
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // Usa Raw para mejor control

        isMoving = horizontal != 0;

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
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        rayCirclePosition = transform.position + rayOffsetCirclePosition;
        Gizmos.DrawWireSphere(rayCirclePosition, rayCircleRadius);
    }
}
