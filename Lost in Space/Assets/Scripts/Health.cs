using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float health = 100;
    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        Debug.Log("(" + gameObject.name + ") Actual health: " + health);
    }
}
