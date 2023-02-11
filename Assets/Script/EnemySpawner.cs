using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnTime = 2f;
    [SerializeField] private Enemy _enemyPrefab;

    private Transform[] _spawnPoints;

    void Start()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        var waitFewSeconds = new WaitForSeconds(_spawnTime);

        for (int i = 1; i < _spawnPoints.Length; i++)
        {
            Instantiate(_enemyPrefab, _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);

            yield return waitFewSeconds;
        }
    }
}
