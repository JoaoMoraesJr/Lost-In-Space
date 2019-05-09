using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public PlayerMovement movement;
    public float runSpeed = 40f;
    public float jetpackFuel = 100;
    public int jetpackCombustion = 100;
    public int jetpackRefill = 10;
    float horizontalMove = 0f;
    bool jump = false;
    bool jetpack = false;
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
        
    }

    private void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
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
        movement.Move(horizontalMove * Time.fixedDeltaTime, false, jump, jetpack);

    }
}
