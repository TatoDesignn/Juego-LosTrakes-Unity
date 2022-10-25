using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    public Image hudA;
    public Image hudR;
    public Image hudV;

    void Start()
    {
        hudA.gameObject.SetActive(false);
        hudR.gameObject.SetActive(false);
        hudV.gameObject.SetActive(false); 

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

        if (Comunicador.playerPrefab.CompareTag("Caleno"))
        {
            hudV.gameObject.SetActive(true);
            Instantiate(Comunicador.playerPrefab, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
    }
}
