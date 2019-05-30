using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Fire;
    public float shotFrequency = 10;
    public float shotRefill = 0;
    public LayerMask TargetLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shotRefill < 100)
        {
            shotRefill += shotFrequency * Time.fixedDeltaTime;
        }
    }

    public void Shot(bool Right)
    {
        if (shotRefill >= 100)
        {
            shotRefill = 0;
            GameObject fire1 = Instantiate(Fire);
            fire1.GetComponent<Projectile>().TargetLayer = TargetLayer;
            fire1.GetComponent<Projectile>().setInitialPosition(transform.position, Right);
        }
    }
}
