using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAttack : MonoBehaviour
{
    public float flyFrequency = 10;
    public float flyRefill = 0;
    public LayerMask TargetLayer;
    public float attackSpeed = 2;
    private Vector3 attackTarget;
    //Add shot velocity

    void Awake()
    {
        attackTarget = this.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flyRefill < 100)
        {
            flyRefill += flyFrequency * Time.fixedDeltaTime;
        }
        transform.position = Vector3.Slerp(transform.position, attackTarget, attackSpeed * Time.deltaTime);
    }

    public void Attack(Vector3 newAttackTarget)
    {
        //Debug.Log("Attack!");
        if (flyRefill >= 100)
        {
            attackTarget = newAttackTarget;
            flyRefill = 0;
        }
    }
}
