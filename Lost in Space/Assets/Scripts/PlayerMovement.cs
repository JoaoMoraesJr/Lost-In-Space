using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;

    private Rigidbody2D m_Rigidbody2D;
    private Vector3 m_Velocity = Vector3.zero;
    private bool m_FacingRight = true;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
    [SerializeField] private float runSpeed = 70;
    [SerializeField] private float m_JumpForce = 400f; // Amount of force added when the player jumps.
    [SerializeField] private float m_JetpackForce = 400f;
    [SerializeField] private float FallSpeed = -25f;
    [SerializeField] private float LittleFallSpeed = -2f;
    [SerializeField] private float FallThreshold = 2f;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    public bool isGrounded;            // Whether or not the player is grounded.

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }



    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
                // Debug.Log("Is Grounded");
                if (!wasGrounded)
                {
                    //Debug.Log("Is Grounded");
                    OnLandEvent.Invoke();
                }
            }
        }

        if (!isGrounded)
        {
            if (GetComponent<Rigidbody2D>().velocity.y < FallThreshold && GetComponent<Rigidbody2D>().velocity.y > 0.01f)
            {
                //Debug.Log("DownImpulse");
                m_Rigidbody2D.AddForce(new Vector2(0f, LittleFallSpeed), ForceMode2D.Impulse);
            }
            else if (GetComponent<Rigidbody2D>().velocity.y > -FallThreshold)
            {
                //Debug.Log("LargeDownImpulse");
                m_Rigidbody2D.AddForce(new Vector2(0f, LittleFallSpeed), ForceMode2D.Impulse);
            }
            else if (GetComponent<Rigidbody2D>().velocity.y < -FallThreshold)
            {
                //Debug.Log("LargeDownImpulse");
                m_Rigidbody2D.AddForce(new Vector2(0f, FallSpeed), ForceMode2D.Impulse);
            }
        }
    }
  
    public void Move(float move, bool crouch, bool jump, bool jetpack)
    {
        move = move * runSpeed;
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        //m_Rigidbody2D.AddForce(new Vector2(move, 0f), ForceMode2D.Impulse);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        // If the player should jump...
        if (isGrounded && jump)
            if (jump)
            {
                // Add a vertical force to the player.
                //m_Grounded = false;
                //animator.SetBool("isJumping", true);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce), ForceMode2D.Impulse);
            }

        if (!isGrounded && jetpack)
        {
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JetpackForce), ForceMode2D.Impulse);
        }

    }


    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
