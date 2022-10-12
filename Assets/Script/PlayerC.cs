using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerC : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    public float velocidad;
    public float salto;

    private bool moving;
    private bool moving2;
    private bool puedeSaltar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movimiento();
        Ataque();
    }

    private void Movimiento()
    {
        if (moving = Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (moving2 = Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        animator.SetBool("Run", moving);
        animator.SetBool("Run2", moving2);

        if(Input.GetKeyDown(KeyCode.W) && puedeSaltar)
        {
            rb.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
            animator.SetBool("Down", true);
            animator.SetTrigger("Jump");
            puedeSaltar = false;
        }
    }

    private void Ataque()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void FixedUpdate()
    {
        Vector2 newVelocity;
        newVelocity.x = Input.GetAxisRaw("Horizontal") * velocidad;
        newVelocity.y = rb.velocity.y;

        rb.velocity = newVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Suelo")
        {
            puedeSaltar = true;
            animator.SetBool("Down", false);
        }
    }

}
