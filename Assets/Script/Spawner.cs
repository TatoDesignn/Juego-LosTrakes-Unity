using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    private GameObject rojo;
    private GameObject azul;
    private GameObject verde;

    public Image hudA;
    public Image hudR;

    void Start()
    {
        hudA.gameObject.SetActive(false);
        hudR.gameObject.SetActive(false);

        

    }

    private void Update()
    {

        if (Comunicador.playerPrefab.CompareTag("Rolo"))
        {
            hudA.gameObject.SetActive(true);
            Instantiate(Comunicador.playerPrefab, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }

        if (Comunicador.playerPrefab.CompareTag("Paisa"))
        {
            hudR.gameObject.SetActive(true);
            Instantiate(Comunicador.playerPrefab, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
    }
}
