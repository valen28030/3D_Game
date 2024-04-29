using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    public Animator MonjeAnim;
    public Animator DemonAnim;
    public float Horizontal;
    public float Vertical;
    public Rigidbody Rigid;
    public float Speed;
    public GameObject Monje;
    public GameObject Demon;
    public GameObject Target;
    public LineRenderer Laser;
    public TextMeshProUGUI Vida;
    public TextMeshProUGUI Enemy;
    private int puntosEnemy = 100;
    private int puntos = 100;
    private bool laserActivado = false;
    public RaycastHit R;
    public bool move;

    // Start is called before the first frame update
    void Start()
    {
        puntos = 100;
        puntosEnemy = 100;
        Laser.enabled = false;
        StartCoroutine(ActivarDesactivarLaser());
    }
    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Raycast();
    }
    IEnumerator ActivarDesactivarLaser()
    {
        // Esperar 15 segundos antes de activar el láser por primera vez
        yield return new WaitForSeconds(15f);
        Laser.enabled = true;
        while (true)
        {
            // Activar el LineRenderer
            Laser.enabled = true;
            laserActivado = true;
            FireLaser();
            
            // Esperar 2 segundos
            yield return new WaitForSeconds(2f);

            // Desactivar el LineRenderer
            Laser.enabled = false;
            laserActivado = false;


            // Esperar 15 segundos antes de repetir el ciclo
            yield return new WaitForSeconds(15f);
        }
    }
    public void Movimiento() {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        if (move == false)
        {
            Rigid.velocity = new Vector3(Horizontal * Speed, Rigid.velocity.y, 0);
            MonjeAnim.SetFloat("VelMov", new Vector3(Horizontal, 0, 0).magnitude);
            Quieto();
            Saltar();
            Patada();
            AddScore();
            DemonAnim.SetTrigger("Ataque");
        }
    }
    public void Raycast() 
    {
        if (Physics.Raycast(Target.transform.position, Target.transform.position, out R, 100))
        {
            Target.transform.position = R.point;
            if (R.transform.tag == "Prota")
            {
                Destroy(R.transform.gameObject);
            }
        }
        Laser.SetPosition(0, Target.transform.position);
        Laser.SetPosition(1, Monje.transform.position);
    }
    public void FireLaser()
    {
        puntos -= 5;
        Vida.text = "Vida: " + puntos;
    }
    public void Quieto()
    {
        if (Horizontal == 0)
        {
            MonjeAnim.SetFloat("VelMov", 0f);
            Speed = 0f;
        }
        else { Andar(); }
    }
    public void Andar()
    {
        if (!move)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                MonjeAnim.SetFloat("VelMov", 0.2f);
                Speed = 2f;
                if (Horizontal < -0.1f)
                { Monje.GetComponent<Transform>().rotation = Quaternion.Euler(0, -90, 0); }
                else { Monje.GetComponent<Transform>().rotation = Quaternion.Euler(0, 90, 0); }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Rigid.AddForce(new Vector3(0, 10, 0));
                }
            }
            else
            {
                Speed = 0f;
            }
            Correr();
            MonjeAnim.SetFloat("VelMov", Speed);
        }
    }
    public void Correr()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            MonjeAnim.SetFloat("VelMov", 0.4f);
            Speed = 5f;
        }
        else if (Input.GetKey(KeyCode.RightShift)) { Speed = 7f; }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Rigid.AddForce(new Vector3(0, 100, 0));
        }
    }
    public void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MonjeAnim.SetTrigger("Salta");

        }
    }
    public void Patada()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MonjeAnim.SetTrigger("Patada");
        }
    }
    public void AddScore()
    {
        if (puntos > 99)
        {
            puntos = 100;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            MonjeAnim.SetTrigger("Recargar");
            puntos += 5;
            Vida.text = "Vida: " + puntos;
        }
    }
    public void RestarScore()
    {
        puntos -= 5;

        if (puntos < 0)
        {
            puntos = 0;
            if (puntos == 0) {
                Vida.text = "Vida: " + puntos;
                MonjeAnim.SetTrigger("Muerte");
                move = true;
            }
        }
        if (puntos > 5)
        {
            Vida.text = "Vida: " + puntos;
            MonjeAnim.SetTrigger("Golpe");
            move = true;
        }
    } 
    public void RestarEnemy()
    {
        puntosEnemy -= 5;
        Enemy.text = "Enemy: " + puntosEnemy;

        if (puntosEnemy < 0)
        {
            puntosEnemy = 0;

        }
        if (puntos > 5)
        {
            Enemy.text = "Enemy: " + puntosEnemy;
            DemonAnim.SetTrigger("Golpe");
        }
        if (puntosEnemy < 5)
        {
            Enemy.text = "Enemy: " + puntosEnemy;
            DemonAnim.SetTrigger("Die");

        }
    }
}