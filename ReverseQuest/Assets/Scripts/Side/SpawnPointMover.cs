using UnityEngine;

public class SpawnPointMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private void Update()
    {
        if (transform.childCount >= 1 && !Obstacle._canSpawnPointMove)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
    }
}
