using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 7.0f; // Fuerza de salto
    private Rigidbody2D rb;
    private bool isGrounded;

    [Header("Animacion")]
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Verificar si el personaje está en el suelo
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Ground"));
        animator.SetBool("enSuelo", isGrounded);

        // Control de movimiento
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        animator.SetFloat("Horizontal", Mathf.Abs(moveX));

        // Saltar si está en el suelo y se presiona la barra espaciadora
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
    }

    private void Saltar()
    {
        // Aplicar una fuerza vertical al objeto para simular el salto
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}




