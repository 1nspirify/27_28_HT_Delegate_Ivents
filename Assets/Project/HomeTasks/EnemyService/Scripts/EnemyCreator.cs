using System;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] public EnemyService _service;
    [SerializeField] public Enemy _enemyPrefab;

    private const KeyCode _key1 = KeyCode.Alpha1;
    private const KeyCode _key2 = KeyCode.Alpha2;
    private const KeyCode _key3 = KeyCode.Alpha3;

    private const int _maxEnemies = 5;
    private const float _lifetime = 5f;

    public void Update()
    {
        if (Input.GetKeyDown(_key1))
        {
            CreateEnemy(EnemyType.LogicDeath);
            Debug.Log($"Жизнь выжила меня");
        }

        if (Input.GetKeyDown(_key2))
        {
            CreateEnemy(EnemyType.LifetimeElapsed);
            Debug.Log($"Родился. По позорил родителей. Умер");
        }

        if (Input.GetKeyDown(_key3))
        {
            CreateEnemy(EnemyType.LackOfSpace);
            Debug.Log($"Неуместный");
        }
    }

    private void CreateEnemy(EnemyType type)
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity, null);
        enemy.Initialize(type);

        float bornTime = Time.time;

        Func<bool> deathReason = type switch
        {
            EnemyType.LifetimeElapsed => () => Time.time - bornTime > _lifetime,
            EnemyType.LackOfSpace => () => _service.EnemiesSpawner.Count >= _maxEnemies,
            EnemyType.LogicDeath => () => true, _ => () => false
        };

        _service.EnemiesSpawner.Add(enemy, deathReason);
    }
}