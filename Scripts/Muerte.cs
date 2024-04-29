using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour
{
    public Controlador Controlador;
    public GameObject Demon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Prota") {
            Controlador.RestarEnemy();
        }
    }

    public void Destruir() {
        Destroy(Demon);
        SceneManager.LoadScene(0);
    }
}

