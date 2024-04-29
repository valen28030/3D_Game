using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgenteController : MonoBehaviour
{
    public NavMeshAgent Demonio;
    public GameObject Monje;
    public Controlador Laser;

    // Update is called once per frame
    void Update()
    {
        Demonio.SetDestination(Monje.transform.position + new Vector3(-2,2,0));
    }
    public void OnCollisionEnter(Collision collision)
    {
        Laser.RestarScore();
    }
}
