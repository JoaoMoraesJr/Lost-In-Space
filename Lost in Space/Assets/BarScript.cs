using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    public Image healthBar;
    public Health PlayerHealth;
    public Image jetpackBar;
    public Jetpack PlayerJetpack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = PlayerHealth.health / 100;
        jetpackBar.fillAmount = PlayerJetpack.jetpackFuel / 100;
    }
}
