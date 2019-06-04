using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    public float FireVelocity = 100f;
    public string TargetLayerName;
    public LayerMask TargetLayer;
    private Vector3 m_Velocity = Vector3.zero;
    public float maxLifeTime = 10f;
    public float currentTime = 0f;
    public float damage = 10f;
    // Start is called before the first frame update
    void Awake()
    {
        //m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setInitialPosition (Transform pos, bool right)
    {
        transform.position = new Vector3(pos.position.x, pos.position.y, pos.position.z);
        setDirection(right);
    }

    private void setDirection(bool right)
    {
        if (right == false)
        {
            FireVelocity = -FireVelocity;
            var main = GetComponent<ParticleSystem>().main;
            main.startSpeed = -5f;
        }
    }

    void FixedUpdate()
    {
        //m_Rigidbody2D.AddForce(new Vector2(FireVelocity, 0f), ForceMode2D.Impulse);
        //Debug.Log("OI");
        transform.position = Vector3.SmoothDamp(transform.position, new Vector2(transform.position.x + (FireVelocity * Time.fixedDeltaTime), transform.position.y) , ref m_Velocity, 0.5f);
        currentTime += 10 * Time.fixedDeltaTime;
        if (currentTime > maxLifeTime)
        {
            Destroy(gameObject);
        }
    }

    public void Dissipate()
    {
        Destroy(gameObject);
    }
}
