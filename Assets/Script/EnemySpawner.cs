using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnTime = 2f;
    [SerializeField] private GameObject _enemyPrefab;

    private Transform[] _spawnPoints;

    void Start()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        for (int i = 1; i < _spawnPoints.Length; i++)
        {
            Instantiate(_enemyPrefab, _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
