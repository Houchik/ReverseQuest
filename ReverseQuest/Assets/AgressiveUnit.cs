using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveUnit : MonoBehaviour
{
    private Transform obstacle0, obstacle1, obstacle2;    

    [SerializeField] float distanceToObstalce;

    float distanceToTarget0;
    float distanceToTarget1;
    float distanceToTarget2;

    public static bool isAttacking;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        obstacle0 = GameObject.Find("Obstacle0").transform;
        obstacle1 = GameObject.Find("Obstacle1").transform;
        obstacle2 = GameObject.Find("Obstacle2").transform;
    }

    void Update()
    {
        if (obstacle0 != null)
        {
            distanceToTarget0 = Vector3.Distance(transform.position, obstacle0.position);
        }

        if(obstacle1 != null)
        {
            distanceToTarget1 = Vector3.Distance(transform.position, obstacle1.position);
        }
        
        if (obstacle2 != null)
        {
            distanceToTarget2 = Vector3.Distance(transform.position, obstacle2.position);
        }
        

        if(distanceToTarget0 < distanceToObstalce && obstacle0 != null
        || distanceToTarget1 < distanceToObstalce && obstacle1 != null
        || distanceToTarget2 < distanceToObstalce && obstacle2 != null)
        {
            Attack();
        }
        else {
            StopAttacking();
        }

        //if (distanceToTarget1 < distanceToObstalce)
        //{
        //    Attack();
        //}
        //else { }

    }

    private void Attack()
    {
        isAttacking = true;
        animator.Play("Attack");
    }

    private void StopAttacking()
    {
        isAttacking = false;
        animator.Play("Idle");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
            Destroy(other.gameObject);
    }
}
