using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Health health;
    public Shooting gun;
    public LayerMask WhatIsPlayer;
    public float RadiusDetection = 15f;
    public Transform Radar;
    public int AttackType = 1;
    private bool Alerted;
    private Transform attackTarget;
    public FlyingAttack flying;
    void Awake()
    {
        health = GetComponent<Health>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Alerted)
        {
            if (AttackType == 1)
            {
                gun.Shot(false);
            }
            if (AttackType == 2)
            {
                flying.Attack(attackTarget.position);
            }
        }
    }

   private void FixedUpdate()
   {
        bool wasAlerted = Alerted;
        Alerted = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(Radar.position, RadiusDetection, WhatIsPlayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                Alerted = true;
                attackTarget = colliders[i].transform;
                //Debug.Log(attackTarget.position);

                //Debug.Log("Alerted!!");
                if (!wasAlerted)
                {
                    //Debug.Log("not Alerted");
                }
            }
        }
   }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            if (Mathf.Log(col.GetComponent<Projectile>().TargetLayer.value, 2) == LayerMask.NameToLayer("Enemy"))
            {
                health.takeDamage(col.GetComponent<Projectile>().damage);
                col.GetComponent<Projectile>().Dissipate();
            }
        }
        
    }

}
