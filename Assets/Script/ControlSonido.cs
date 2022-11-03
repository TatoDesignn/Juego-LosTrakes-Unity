using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSonido : MonoBehaviour
{

    AudioSource audio1;

    [SerializeField] AudioClip movimiento;
    [SerializeField] AudioClip Salto;

    private void Start()
    {
        audio1 = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            audio1.PlayOneShot(movimiento);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            audio1.PlayOneShot(Salto);
        }
    }
}
