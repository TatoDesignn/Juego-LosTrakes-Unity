using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    Animator animator;

    public Rigidbody2D rb2;

    public Transform jugador;

    public bool mirando = true;

    public int vidaEnemigo;
    public int vida;

    public float distanciaJugador;
    private void Start()
    {
        animator = GameObject.FindGameObjectWithTag("EnemigoHud").GetComponent<Animator>();
        jugador = Comunicador.playerPrefab.GetComponent<Transform>();

        rb2 = GetComponent<Rigidbody2D>();

        vidaEnemigo = 1;
        vida = 3;
    }

    private void Update()
    {
        if (mirando)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        else if(!mirando)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("DistanciaJugador", distanciaJugador);
    }

    public void Dano(int danoG)
    {
        vidaEnemigo += danoG;

        if(vidaEnemigo == 4)
        {
            vida -= 1;
            vidaEnemigo = 1;

            if (vida == 0)
            {
                Destroy(gameObject);
                Destroy(GameObject.FindGameObjectWithTag("EnemigoHud"));
            }
        }

        if (vida == 3 && vidaEnemigo == 2)
        {
            animator.SetTrigger("3V2H");
        }

        if (vida == 3 && vidaEnemigo == 3)
        {
            animator.SetTrigger("3V3H");
        }

        if (vida == 2 && vidaEnemigo == 1)
        {
            animator.SetTrigger("2V1H");
        }

        if (vida == 2 && vidaEnemigo == 2)
        {
            animator.SetTrigger("2V2H");
        }

        if (vida == 2 && vidaEnemigo == 3)
        {
            animator.SetTrigger("2V3H");
        }

        if (vida == 1 && vidaEnemigo == 1)
        {
            animator.SetTrigger("1V1H");
        }

        if (vida == 1 && vidaEnemigo == 2)
        {
            animator.SetTrigger("1V2H");
        }

        if (vida == 1 && vidaEnemigo == 3)
        {
            animator.SetTrigger("1V3H");
        }
    }

    public void MirarJugador()
    {
        if((jugador.position.x > transform.position.x && !mirando) || (jugador.position.x < transform.position.x && mirando))
        {
            mirando = !mirando;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }
}

