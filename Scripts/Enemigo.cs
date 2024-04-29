using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float TimeToAttack;
    public int Attacks;
    public float Speed;
    public Animator Anim;
    private float AttackTime;
    private bool bAttacking;
    public Vector3 MovementVect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!bAttacking)
        {
            
            AttackTime += Time.deltaTime;
        }

        if (AttackTime >= TimeToAttack)
        {
            bAttacking = true;
            int r = Random.Range(1, Attacks + 1);
            Anim.SetInteger("Attack", r);
            AttackTime = 0;
        }
    }
    public void EndAttack()
    {
        bAttacking = false;
        Anim.SetInteger("Attack", 0);
    }
}

