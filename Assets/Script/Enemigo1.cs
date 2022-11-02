using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemigo1 : MonoBehaviour
{
    Animator animator;
    Animator animator2;

    public Rigidbody2D rb2;

    public Transform jugador;

    public Image victoria;

    public Transform controladorGolpe;
    public float radio;

    public bool mirando = true;
    public bool puede = true;

    public int vidaEnemigo;
    public int vida;

    public int cargar;

    public int danoGolpe; 

    private void Start()
    {
        animator = GameObject.FindGameObjectWithTag("EnemigoHud").GetComponent<Animator>();

        animator2 = GetComponent<Animator>();

        rb2 = GetComponent<Rigidbody2D>();

        victoria.gameObject.SetActive(false);

        vidaEnemigo = 1;
        vida = 3;

        Invoke("Fijar", 0.1f);
    }

    private void Update()
    {
        if (mirando)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        else if (!mirando)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        Invoke("Calcular", 0.2f);
    }

    private void Fijar()
    {
        if (Comunicador.playerPrefab.CompareTag("Rolo"))
        {
            jugador = GameObject.FindGameObjectWithTag("Rolo").GetComponent<Transform>();
        }

        if (Comunicador.playerPrefab.CompareTag("Paisa"))
        {
            jugador = GameObject.FindGameObjectWithTag("Paisa").GetComponent<Transform>();
        }

        if (Comunicador.playerPrefab.CompareTag("Caleno"))
        {
            jugador = GameObject.FindGameObjectWithTag("Caleno").GetComponent<Transform>();
        }

    }

    private void Calcular()
    {

        if (puede)
        {
            float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
            animator2.SetFloat("DistanciaJugador", distanciaJugador);
        }

    }
    
    public void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radio);

        foreach (Collider2D collisionador in objetos)
        {
            if (collisionador.CompareTag("Rolo"))
            {
                collisionador.transform.GetComponent<PlayerC>().Dano(danoGolpe);
            }

            if (collisionador.CompareTag("Paisa"))
            {
                collisionador.transform.GetComponent<PlayerC2>().Dano(danoGolpe);
            }


            if (collisionador.CompareTag("Caleno"))
            {
                collisionador.transform.GetComponent<PlayerC3>().Dano(danoGolpe);
            }
        }
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
                victoria.gameObject.SetActive(true);
                
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

    public void Victoria()
    {
        SceneManager.LoadScene(cargar);
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
