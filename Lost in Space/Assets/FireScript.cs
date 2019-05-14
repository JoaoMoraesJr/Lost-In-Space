using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    public float FireVelocity = 10f;
    private Vector3 m_Velocity = Vector3.zero;
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

    void FixedUpdate()
    {
        //m_Rigidbody2D.AddForce(new Vector2(FireVelocity, 0f), ForceMode2D.Impulse);
        //Debug.Log("OI");
        transform.position = Vector3.SmoothDamp(transform.position, new Vector2(transform.position.x+10, transform.position.y) , ref m_Velocity, 0.5f);
    }
}
