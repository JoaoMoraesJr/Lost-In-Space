using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{

    public bool isActive = false;
    public float jetpackFuel = 100;
    public int jetpackCombustion = 100;
    public int jetpackRefill = 10;
    public ParticleSystem jetpackPrefab;
    private ParticleSystem jetpackParticles;
    public Transform jetpackPosition;
    private void Awake()
    {
        jetpackParticles = Instantiate(jetpackPrefab);
        jetpackParticles.transform.SetParent(this.transform);
    }

    // Start is called before the first frame update
    void Start()
    {

        jetpackParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //Recharge jetpack
        if (!isActive && jetpackFuel < 100)
        {
            jetpackFuel = jetpackFuel + jetpackRefill * Time.fixedDeltaTime;
        }

        //Activate particles
        if (isActive)
        {
            if (!jetpackParticles.isPlaying)
            {
                Debug.Log("Active!");
                jetpackParticles.Play();
            }
        }
        else
        {
            Debug.Log("Deactivate!");
            jetpackParticles.Stop();
        }
    }


    public void Activate()
    {
        isActive = false;
        if (jetpackFuel > 0)
        {
            jetpackFuel = jetpackFuel - jetpackCombustion * Time.fixedDeltaTime;
            isActive = true;
        }
    }

    public void Deactivate()
    {
        isActive = false;
    }
}
