using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]

public class Enemy : MonoBehaviour
{
    [SerializeField] public float _speed;

    private Renderer _renderer;
    private Rigidbody _rigidbody;
    private GameObject _target;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    public void Init(Vector3 startPosition, Quaternion rotation, Vector3 velocity, GameObject target)
    {
        transform.position = startPosition;
        transform.rotation = rotation;
        _rigidbody.velocity = velocity;
        _target = target;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        transform.LookAt(_target.transform.position);
    }
}

