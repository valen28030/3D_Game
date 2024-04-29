using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public Controlador Controlador;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") {
            Controlador.RestarScore();
        }
    }
    public void Recargar()
    {
        SceneManager.LoadScene(0);
    }

    public void Inmove() 
    {
        Controlador.move = false;
    }
}
