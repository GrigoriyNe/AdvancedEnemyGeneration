using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private GameObject _target;

    private int _delayCreating = 2;
    private Coroutine _coroutine;
    private WaitForSeconds _wait; 

    private void Start()
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(CreateWhithDelay());
    }

    private IEnumerator CreateWhithDelay()
    {
        _wait = new WaitForSeconds(_delayCreating);

        while (enabled)
        {
            Enemy enemy = Instantiate(_enemy);

            var startPosition = GetRandomStartPosition();
            GameObject target = _target;
            var rotation = Quaternion.identity;
            Vector3 rigidbody = Vector3.zero;

            enemy.Init(startPosition, rotation, rigidbody, target);
            

            yield return _wait;
        }
    }

    private Vector3 GetRandomStartPosition()
    {
        int minRandomValue = -15;
        int maxRandomValue = 15;

        return new Vector3(
            transform.position.x + Random.Range(minRandomValue, maxRandomValue),
            transform.position.y,
            transform.position.z + Random.Range(minRandomValue, maxRandomValue));
    }
}
