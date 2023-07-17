using System.Collections;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private int _attackInterval;

    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    public virtual void Attack()
    {
        StartCoroutine(AttackCooldown());
    }

    public void GetDamage(int damage)
    {
        health.RecieveDamage(damage);
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(_attackInterval);
        Attack();
    }
}
