using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    private Vector3 _standartSpawnPointPosition;

    private void Start()
    {
        _standartSpawnPointPosition = transform.position;
    }

    private void Update()
    {
        if (transform.childCount >= 1)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }

        else
        {
            transform.position = _standartSpawnPointPosition;
        }
    }
}
