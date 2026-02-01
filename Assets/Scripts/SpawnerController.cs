using System.Collections;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyPrefab;
    [SerializeField] private float _spawnEvery = 2.0f;
    [SerializeField] private float _spawnVerticalPositionShift = 0.2f;
    
    private SpawnPointSettings[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = gameObject.GetComponentsInChildren<SpawnPointSettings>();
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
        SpawnPointSettings spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        Vector3 position = spawnPoint.transform.position + new Vector3(0, _spawnVerticalPositionShift, 0);
        
        EnemyController spawnedEnemy = Instantiate(_enemyPrefab,  position, Quaternion.identity);
        spawnedEnemy.MoveDirection = spawnPoint.Direction;
    }
}
