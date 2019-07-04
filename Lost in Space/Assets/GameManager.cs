using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Boss;
    public Animator winAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Health>().health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene(0, LoadSceneMode.Additive);
        }

        if (Boss.GetComponent<Health>().health <= 0)
        {
            winAnim.SetBool("BossDead", true);
        }

    }
}
