using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerC : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Animator animatorHud;
    Enemigo1 enemy;
    Perder perdio;

    public float velocidad;
    public float salto;

    public int vida;
    private int vida2;

    public float tiempoEntre;
    private float tiempoSiguiente;

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
        animatorHud = GameObject.FindGameObjectWithTag("RoloHud").GetComponent<Animator>();
        perdio = GameObject.FindGameObjectWithTag("Perde").GetComponent<Perder>();

        vida2 = 1;
        vida = 3;

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
        if(tiempoSiguiente > 0)
        {
            tiempoSiguiente -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.E) && tiempoSiguiente <= 0)
        {
            tiempoSiguiente = tiempoEntre;
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

    public void Dano(int danoG)
    {
        vida2 += danoG;

        if (vida2 == 4)
        {
            vida -= 1;
            vida2 = 1;

            if (vida == 0)
            {
                perdio.Perdio();
                enemy.puede = false;
                Destroy(gameObject);
                Destroy(GameObject.FindGameObjectWithTag("RoloHud"));
            }
        }

        if (vida == 3 && vida2 == 2)
        {
            animatorHud.SetTrigger("3V2H");
        }

        if (vida == 3 && vida2 == 3)
        {
            animatorHud.SetTrigger("3V3H");
        }

        if (vida == 2 && vida2 == 1)
        {
            animatorHud.SetTrigger("2V1H");
        }

        if (vida == 2 && vida2 == 2)
        {
            animatorHud.SetTrigger("2V2H");
        }

        if (vida == 2 && vida2 == 3)
        {
            animatorHud.SetTrigger("2V3H");
        }

        if (vida == 1 && vida2 == 1)
        {
            animatorHud.SetTrigger("1V1H");
        }

        if (vida == 1 && vida2 == 2)
        {
            animatorHud.SetTrigger("1V2H");
        }

        if (vida == 1 && vida2 == 3)
        {
            animatorHud.SetTrigger("1V3H");
        }
    }

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
        if(collision.collider.tag == "Suelo")
        {
            puedeSaltar = true;
            animator.SetBool("Down", false);
        }
    }

}
