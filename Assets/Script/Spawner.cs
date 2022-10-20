using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    private GameObject rojo;
    private GameObject azul;
    private GameObject verde;

    public Image hudA;

    void Start()
    {
        Instantiate(Comunicador.playerPrefab, this.transform.position, this.transform.rotation);

        /*rojo = GameObject.FindGameObjectWithTag("Paisa");
        azul = GameObject.FindGameObjectWithTag("Rolo");
        verde = GameObject.FindGameObjectWithTag("Caleño");*/

    }

    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Rolo").activeInHierarchy == true)
        {
            hudA.gameObject.SetActive(true);
        }

       /* if (rojo.activeInHierarchy == true)
        {
            
        }

        if (verde.activeInHierarchy == true)
        {
            
        }*/
    }
}
