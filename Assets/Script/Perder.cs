using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Perder : MonoBehaviour
{
    PlayerC jugador;
    PlayerC2 jugador2;
    PlayerC3 jugador3;

    public Image perder;

    void Start()
    {
        perder.gameObject.SetActive(false);

        /*if(Comunicador.playerPrefab.CompareTag("Rolo"))
        {
            jugador = Comunicador.playerPrefab.GetComponent<PlayerC>();
        }


        if (Comunicador.playerPrefab.CompareTag("Paisa"))
        {
            jugador2 = Comunicador.playerPrefab.GetComponent<PlayerC2>();
        }

        if (Comunicador.playerPrefab.CompareTag("Caleno"))
        {
            jugador3 = Comunicador.playerPrefab.GetComponent<PlayerC3>();
        }*/
    }

    /*private void Update()
    {
        if (Comunicador.playerPrefab.CompareTag("Rolo"))
        {
            if (jugador.vida == 1);
            {
                Perdio();
            }
        }

        if (Comunicador.playerPrefab.CompareTag("Paisa"))
        {
            if (jugador2.vida == 0)
            {
                Perdio();
            }
        }

        if (Comunicador.playerPrefab.CompareTag("Caleno"))
        {
            if (jugador3.vida == 0)
            {
                Perdio();
            }
        }
    }*/

    public void Perdio()
    {
        perder.gameObject.SetActive(true);

        Invoke("Cambio", 2);
    }

    private void Cambio()
    {
        SceneManager.LoadScene(1);
    }
}
