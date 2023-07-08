using System;

public class Ally : Unit
{
    public static Action<int> onAllyAttacked;

    public override void Attack()
    {
        onAllyAttacked?.Invoke(_damage);
        base.Attack();
    }

    protected override void OnDestroy()
    {
        Enemy.onEnemyAttacked -= GetDamage;
        base.OnDestroy();
    }
}
