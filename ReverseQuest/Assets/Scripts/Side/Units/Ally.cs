using System;
using UnityEngine;

public class Ally : Unit
{
    public static Action<int> onAllyAttacked;

    [SerializeField] private int _damage;

    public override void Attack()
    {
        if (onAllyAttacked != null)
        {
            onAllyAttacked.GetInvocationList()[0].DynamicInvoke(_damage);
        }

        else
        {
            return;
        }

        base.Attack();
    }

    private void OnDestroy()
    {
        Enemy.onEnemyAttacked -= GetDamage;
    }
}
