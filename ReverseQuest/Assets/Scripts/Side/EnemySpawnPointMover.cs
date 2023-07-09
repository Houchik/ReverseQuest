public class EnemySpawnPointMover : SpawnPointMover
{
    protected override void Update()
    {
        if (Enemy.onEnemyAttacked == null)
        {
            base.Update();
        }
    }
}
