using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Health health;
    public Shooting gun;
    const float RadiusDetection = 15f;
    public LayerMask m_WhatIsPlayer;
    public Transform m_Radar;
    private bool m_Alerted;
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
        if (m_Alerted)
        {
            gun.Shot(false);
        }
    }

   private void FixedUpdate()
   {
        Debug.Log(m_Alerted);
        bool wasAlerted = m_Alerted;
        m_Alerted = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_Radar.position, RadiusDetection, m_WhatIsPlayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Alerted = true;
                Debug.Log("Alerted!!");
                if (!wasAlerted)
                {
                    Debug.Log("not Alerted");
                }
            }
        }
   }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            if (col.GetComponent<Projectile>().TargetLayer == LayerMask.NameToLayer("Enemy"))
            {
                health.takeDamage(col.GetComponent<Projectile>().damage);
                col.GetComponent<Projectile>().Dissipate();
            }
        }
        
    }

}
