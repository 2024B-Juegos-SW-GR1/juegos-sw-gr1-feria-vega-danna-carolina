using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f; // Ajusta este valor según la gravedad
    private Rigidbody2D _rb;
    private bool isGrounded;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        float move = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(move * moveSpeed, _rb.velocity.y);

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce); // Establece una velocidad vertical controlada
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Solo permite saltar cuando está tocando el suelo
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Evita que salte en el aire
        }
    }
}
