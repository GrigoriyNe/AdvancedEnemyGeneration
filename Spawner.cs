using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Target))]

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Target _target;

    private int _delayCreating = 2;
    private Coroutine _coroutine;

    private void Start()
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(CreateWhithDelay());
    }

    private IEnumerator CreateWhithDelay()
    {
        WaitForSeconds wait = new WaitForSeconds(_delayCreating);

        while (enabled)
        {
            Enemy enemy = Instantiate(_enemy);

            var startPosition = GetRandomStartPosition();
            Target target = _target;
            var rotation = Quaternion.identity;
            var velocity = Vector3.zero;

            enemy.Init(startPosition, rotation, velocity, target);
            
            yield return wait;
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
