using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    Animator animator;

    public int vidaEnemigo;
    public int vida;

    private void Start()
    {
        animator = GameObject.FindGameObjectWithTag("EnemigoHud").GetComponent<Animator>();

        vidaEnemigo = 1;
        vida = 3;
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
}
