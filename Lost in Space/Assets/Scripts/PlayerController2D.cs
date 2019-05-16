using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public PlayerMovement movement;
    public float runSpeed = 40f;
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool facingRight = true;

    private bool jetpack = false;
    private float jetpackFuel = 100;
    public int jetpackCombustion = 100;
    public int jetpackRefill = 10;

    public GameObject Fire;
    public float shotFrequency = 10;
    public float shotRefill = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jetpack == false && jetpackFuel < 100)
        {
            jetpackFuel = jetpackFuel + jetpackRefill * Time.fixedDeltaTime;
        }

        if (shotRefill < 100)
        {
            shotRefill += shotFrequency * Time.fixedDeltaTime;
        }
        
    }

    private void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (horizontalMove > 0)
        {
            facingRight = true;
        } else if (horizontalMove < 0)
        {
            facingRight = false;
        }

        jump = false;
        jetpack = false;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButton("Jetpack") && (jetpackFuel > 0 ))
        {
            jetpackFuel = jetpackFuel - jetpackCombustion * Time.fixedDeltaTime;
            jetpack = true;
        }
        if (Input.GetButton("Fire1") && shotRefill >= 100)
        {
            //Debug.Log("Fire");
            shotRefill = 0;
            GameObject fire1 = Instantiate(Fire);
            fire1.GetComponent<FireScript>().setInitialPosition(transform.position, facingRight);
        }
        movement.Move(horizontalMove * Time.fixedDeltaTime, false, jump, jetpack);

    }
}
