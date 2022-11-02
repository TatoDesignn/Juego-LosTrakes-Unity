using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScena : MonoBehaviour
{

    public int cargar;

    private void Update()
    {
        if(gameObject.activeInHierarchy == true)
        {
            Invoke("Victoria", 1);
        }
    }

    public void Victoria()
    {
        SceneManager.LoadScene(cargar);
    }
}
