using System.Collections;
using UnityEngine;
using System;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] private int _attackInterval;

    [SerializeField] private int _startHP;
    private int _currentHP;

    private void Start()
    {
        _currentHP = _startHP;
    }

    public abstract void Attack();

    public void GetDamage(int damage)
    {
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log(_currentHP + gameObject.name);
    }

    public IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(_attackInterval);
        Attack();
    }
}
