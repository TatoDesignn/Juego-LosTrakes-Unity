using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScena : MonoBehaviour
{

    public int cargar;

    AudioSource audio1;

    [SerializeField] AudioClip rolo;
    [SerializeField] AudioClip paisa;
    [SerializeField] AudioClip caleno;

    private void Start()
    {
        audio1 = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(gameObject.activeInHierarchy == true)
        {
            Invoke("Victoria", 3);
        }

        if (Comunicador.playerPrefab.CompareTag("Rolo"))
        {
            audio1.PlayOneShot(rolo);
        }

        if (Comunicador.playerPrefab.CompareTag("Paisa"))
        {
            audio1.PlayOneShot(paisa);
        }

        if (Comunicador.playerPrefab.CompareTag("Caleno"))
        {
            audio1.PlayOneShot(caleno);
        }
    }

    public void Victoria()
    {
        SceneManager.LoadScene(cargar);
    }
}
