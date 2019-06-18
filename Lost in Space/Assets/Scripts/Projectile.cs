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
    private bool shot = false;

    public ParticleSystem shotParticles;
    public ParticleSystem dissipateParticle;
    // Start is called before the first frame update
    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
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
        shotParticles.Play();
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
        //if (Type == ProjectileType.Falling && !shot) //BUG BUG BUG BUG
        //{
         //   m_Rigidbody2D.AddForce(new Vector2(2f, 0f));
          //  shot = true;
        //}
        //if (Type == ProjectileType.Straight)
        //{
            transform.position = Vector3.SmoothDamp(transform.position, new Vector2(transform.position.x + (FireVelocity * Time.fixedDeltaTime), transform.position.y), ref m_Velocity, 0.5f);
        //}
        currentTime += 10 * Time.fixedDeltaTime;
        if (currentTime > maxLifeTime)
        {
            Destroy(gameObject);
        }
    }

    public void Dissipate()
    {
        ParticleSystem aux = Instantiate(dissipateParticle, transform.position, Quaternion.identity);
        aux.Play();
        Destroy(gameObject);
    }


}
