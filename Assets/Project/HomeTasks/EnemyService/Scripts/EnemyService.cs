using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoBehaviour
{
    public List<Enemy> Enemies;
    public Dictionary<Enemy, Func<bool>> EnemiesSpawner = new();

    private void Update()
    {
        List<Enemy> deadList = new List<Enemy>();
        Debug.Log(Enemies.Count);

        foreach (var pair in EnemiesSpawner)
        {
            if (pair.Value())
            {
                Destroy(pair.Key.gameObject);
                deadList.Add(pair.Key);
                Debug.Log($"Enemy died due to {pair.Key.Type}");
            }
        }

        foreach (var dead in deadList)
        {
            Enemies.Remove(dead);
            EnemiesSpawner.Remove(dead);
        }
    }
}