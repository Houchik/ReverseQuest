using System.Collections;
using UnityEngine;
using System;

public abstract class Unit : MonoBehaviour
{
    public static Action<int> onAttacked;

    [SerializeField] private int _damage;
    [SerializeField] private int _attackInterval;

    private void Attack()
    {
        onAttacked?.Invoke(_damage);
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(_attackInterval);
        Attack();
    }
}
