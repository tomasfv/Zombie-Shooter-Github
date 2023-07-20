using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _minimumSpawnTime;

    [SerializeField]
    private float _maximumSpawnTime;

    [SerializeField]
    private float _minSpawnRangeX;

    [SerializeField]
    private float _maxSpawnRangeX;

    [SerializeField]
    private float _minSpawnRangeY;

    [SerializeField]
    private float _maxSpawnRangeY;
    
    private float _timeUntilSpawn;

    private Transform _playerPos;

    private GameManager _gameManager;

    

    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
        _playerPos = FindObjectOfType<PlayerController>().transform;
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spawnPos = new Vector3(Random.Range(_minSpawnRangeX, _maxSpawnRangeX), Random.Range(_minSpawnRangeY, _maxSpawnRangeY), 0);
        _timeUntilSpawn -= Time.deltaTime;

        if(_timeUntilSpawn <= 0 && spawnPos != _playerPos.position && _gameManager.enemiesInScene < _gameManager.enemiesInstancesLimit)
        {
            //Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
            GameObject enemy = EnemyPool.instance.GetPooledObject();
            if (enemy != null)
            {
                enemy.transform.position = spawnPos;
                //enemy.transform.rotation = Quaternion.identity;
                enemy.SetActive(true);
            }
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
