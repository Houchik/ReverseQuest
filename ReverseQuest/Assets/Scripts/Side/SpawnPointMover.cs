using UnityEngine;

public abstract class SpawnPointMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    protected virtual void Update()
    {
        transform.Translate(transform.forward * _speed * Time.deltaTime, Space.World);
    }
}
