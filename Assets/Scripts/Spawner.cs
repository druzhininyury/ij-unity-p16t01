using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnEvery = 2.0f;
    [SerializeField] private float _spawnVerticalPositionShift = 0.2f;
    
    private SpawnPoint[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = gameObject.GetComponentsInChildren<SpawnPoint>();
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnEvery);
        
        while (true)
        {
            SpawnEnemy();
            yield return waitForSeconds;
        }
    }

    private void SpawnEnemy()
    {
        SpawnPoint spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        Vector3 position = spawnPoint.transform.position + new Vector3(0, _spawnVerticalPositionShift, 0);
        
        Enemy spawnedEnemy = Instantiate(_enemyPrefab,  position, Quaternion.identity);
        spawnedEnemy.target = spawnPoint.Target.transform;
    }
}
