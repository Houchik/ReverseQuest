using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public static bool _canSpawnPointMove = true;

    private Transform _spawnPoint;

    private float _stopDistance = 1;

    private void Start()
    {
        _spawnPoint = GameObject.Find("UnitSpawnPoint").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(_spawnPoint.position, transform.position) <= _stopDistance)
        {
            _canSpawnPointMove = false;
        }
    }

    private void OnDestroy()
    {
        _canSpawnPointMove = true;
    }
}
