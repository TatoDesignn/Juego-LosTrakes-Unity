using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    void Start()
    {
        Instantiate(Comunicador.playerPrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
