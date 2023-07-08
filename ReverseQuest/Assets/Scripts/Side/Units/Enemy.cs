using System;

public class Enemy : Unit
{
    public static Action<int> onEnemyAttacked;

    public override void Attack()
    {
        onEnemyAttacked?.Invoke(_damage);
        base.Attack();
    }

    protected override void OnDestroy()
    {
        Ally.onAllyAttacked -= GetDamage;
        base.OnDestroy();
    }
}
