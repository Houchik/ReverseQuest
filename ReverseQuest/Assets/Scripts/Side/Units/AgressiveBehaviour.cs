using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveBehaviour : MonoBehaviour
{
    [SerializeField] Transform[] attackTarget;

    [SerializeField] float attackRange;
    [SerializeField] float moveSpeed;

    private float distanceToAttackTarget;

    private Rigidbody _rigibody;

    void Start()
    {
        _rigibody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToAttackTarget = Vector3.Distance(transform.position, attackTarget[0].position);
    }
}
