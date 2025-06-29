using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnemySerialize
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Prefabs")] 
        [SerializeField] private Ninja _ninjaPrefab;
        [SerializeField] private Samurai _samuraiPrefab;
        [SerializeField] private Imperor _imperorPrefab;

        [Header("Configs")] 
        [SerializeField] private List<NinjaConfig> _ninjaConfigs;
        [SerializeField] private List<SamuraiConfig> _samuraiConfigs;
        [SerializeField] private List<ImperorConfig>  _imperorConfigs;
        
        private void Start()
        {
            foreach (NinjaConfig config in _ninjaConfigs)
                Spawn(config);

            foreach (SamuraiConfig config in _samuraiConfigs)
                Spawn(config);

            foreach (ImperorConfig config in _imperorConfigs)
                Spawn(config);
        }

        public Enemy Spawn(EnemyConfig config)
        {
            if (config == null)
            {
                Debug.LogError("Config is null");
                return null;
            }

            Enemy instance = null;

            switch (config)
            {
                case NinjaConfig ninjaConfig:
                    Ninja ninja = Instantiate(_ninjaPrefab, GetRandomSpawnPosition(), Quaternion.identity);
                    ninja.Initialize(ninjaConfig);
                    break;

                case SamuraiConfig samuraiConfig:
                    Samurai samurai = Instantiate(_samuraiPrefab, GetRandomSpawnPosition(), Quaternion.identity);
                    samurai.Initialize(samuraiConfig);
                    break;

                case ImperorConfig imperorConfig:
                    Imperor imperor = Instantiate(_imperorPrefab, GetRandomSpawnPosition(), Quaternion.identity);
                    imperor.Initialize(imperorConfig);
                    break;

                default:
                    Debug.LogError($"Unknown config type: {config.GetType()}");
                    break;
            }

            return instance;
        }

        private Vector3 GetRandomSpawnPosition()
        {
            return new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
        }
    }
    
}