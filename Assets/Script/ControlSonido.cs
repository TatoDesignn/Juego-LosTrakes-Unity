using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSonido : MonoBehaviour
{

    AudioSource audio1;

    [SerializeField] AudioClip Salto;
    [SerializeField] AudioClip Golpe;

    private void Start()
    {
        audio1 = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            audio1.PlayOneShot(Salto);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            audio1.PlayOneShot(Golpe);
        }
    }
}
