using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC2 : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Animator animatorHud;
    Enemigo1 enemy;

    public float velocidad;
    public float salto;

    public int vida;

    public int danoGolpe;
    public Transform controladorGolpe;
    public float radio;

    private bool moving;
    private bool moving2;
    private bool puedeSaltar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemigo").GetComponent<Enemigo1>();
        animator = GetComponent<Animator>();
        animatorHud = GameObject.FindGameObjectWithTag("PaisaHud").GetComponent<Animator>();


    }

    void Update()
    {
        //ControlHud();
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

        if (Input.GetKeyDown(KeyCode.W) && puedeSaltar)
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
            Golpe();
        }
    }

    private void Golpe()
    {
        animator.SetTrigger("Attack");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radio);

        foreach (Collider2D collisionador in objetos)
        {
            if (collisionador.CompareTag("Enemigo"))
            {
                collisionador.transform.GetComponent<Enemigo1>().Dano(danoGolpe);
            }
        }
    }

    /*private void ControlHud()
    {
        if (vida == 3 && enemy.vidaEnemigo == 2)
        {
            animatorHud.SetTrigger("3V2H");
        }

        if (vida == 3 && enemy.vidaEnemigo == 1)
        {
            animatorHud.SetTrigger("3V3H");
        }

        if (vida == 2 && enemy.vidaEnemigo == 3)
        {
            animatorHud.SetTrigger("2V1H");
        }

        if (vida == 2 && enemy.vidaEnemigo == 2)
        {
            animatorHud.SetTrigger("2V2H");
        }

        if (vida == 2 && enemy.vidaEnemigo == 1)
        {
            animatorHud.SetTrigger("2V1H");
        }

        if (vida == 1 && enemy.vidaEnemigo == 3)
        {
            animatorHud.SetTrigger("1V1H");
        }

        if (vida == 1 && enemy.vidaEnemigo == 2)
        {
            animatorHud.SetTrigger("1V2H");
        }

        if (vida == 1 && enemy.vidaEnemigo == 1)
        {
            animatorHud.SetTrigger("1V3H");
        }
    }*/

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(controladorGolpe.position, radio);
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
        if (collision.collider.tag == "Suelo")
        {
            puedeSaltar = true;
            animator.SetBool("Down", false);
        }
    }
}
