using System;

public class Enemy : Unit
{
    public static Action<int> onEnemyAttacked;

    public override void Attack()
    {
        if (onEnemyAttacked != null)
        {
            onEnemyAttacked.GetInvocationList()[0].DynamicInvoke(_damage);
        }

        else
        {
            return;
        }

        base.Attack();
    }

    private void OnDestroy()
    {
        Ally.onAllyAttacked -= GetDamage;
    }
}
