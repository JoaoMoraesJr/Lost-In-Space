using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Health health;

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
        
    }

    //private void FixedUpdate()
    //{
    //    bool wasGrounded = m_Grounded;
    //    m_Grounded = false;

    //    // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
    //    // This can be done using layers instead but Sample Assets will not overwrite your project settings.
    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
    //    for (int i = 0; i < colliders.Length; i++)
    //    {
    //        if (colliders[i].gameObject != gameObject)
    //        {
    //            m_Grounded = true;
    //            // Debug.Log("Is Grounded");
    //            if (!wasGrounded)
    //            {
    //                Debug.Log("Is Grounded");
    //                OnLandEvent.Invoke();
    //            }
    //        }
    //    }
    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            health.takeDamage(col.GetComponent<Projectile>().damage);
        }
        
    }

}
