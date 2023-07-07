using System;

public class Ally : Unit
{
    public static Action<int> onAllyAttacked;

    public override void Attack()
    {
        onAllyAttacked?.Invoke(_damage);
        StartCoroutine(AttackCooldown());
    }

    private void OnDestroy()
    {
        Enemy.onEnemyAttacked -= GetDamage;
        foreach (SpawnPointMover spawnPointMover in FindObjectsByType<SpawnPointMover>(UnityEngine.FindObjectsSortMode.None))
        {
            spawnPointMover.enabled = true;
        }
    }
}
