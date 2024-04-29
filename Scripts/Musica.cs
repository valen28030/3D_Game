using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Musica : MonoBehaviour
{
    public AudioSource musica;
    public AudioClip[] canciones;
    public int cancionsonando;

    // Start is called before the first frame update
    void Start()
    {
        Reproducir(0);
        musica.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        NextAutomatico();
    }

    public void Reproducir(int id) 
    {
        
        musica.clip = canciones[id];
        cancionsonando = id;
        musica.Play();
    }
    // Pasa de cancion automaticamente cuando llega al final.
    public void NextAutomatico()
    {
        if (musica.clip != null)
        {
            
            if (musica.isPlaying && musica.time >= musica.clip.length - 0.1f) // 0.1f es un peque?o margen para asegurarse de que hemos llegado al final.
            {
                Next();
            }
        }
    }

    // Pasa a la siguiente canci?n detectando si esta en normal o en aleatorio.
    public void Next()
    {
        cancionsonando++;
        if (cancionsonando >= canciones.Length)
        {
                cancionsonando = 0;
        }
        Reproducir(cancionsonando);
    }
}

