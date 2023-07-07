using System;

public class Enemy : Unit
{
    public static Action<int> onEnemyAttacked;

    public override void Attack()
    {
        onEnemyAttacked?.Invoke(_damage);
        StartCoroutine(AttackCooldown());
    }

    private void OnDestroy()
    {
        Ally.onAllyAttacked -= GetDamage;
        foreach (SpawnPointMover spawnPointMover in FindObjectsByType<SpawnPointMover>(UnityEngine.FindObjectsSortMode.None))
        {
            spawnPointMover.enabled = true;
        }
    }
}
