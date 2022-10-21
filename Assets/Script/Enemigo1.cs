using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public int vidaEnemigo;

    public void Dano(int danoG)
    {
        vidaEnemigo -= danoG;

        if(vidaEnemigo == 0)
        {
            Destroy(gameObject);
        }
    }
}
