using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour, ISceneCycle, ISceneCycleAwake
    {
        [Header("Spawn"), SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private GameObject _character;
        [SerializeField] private Transform _worldTransform;
        [Header("Pool"), SerializeField] private Transform _container;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _enemyObject;
        private readonly Queue<GameObject> _enemyPool = new();

        public void CycleAwake()
        {
            SceneCycleController sceneCycleController = FindAnyObjectByType<SceneCycleController>();

            for (var i = 0; i < _enemyObject; i++)
            {
                
                var enemy = Instantiate(_prefab, _container);

                EnemyMoveAgent enemyMoveAgent = enemy.GetComponent<EnemyMoveAgent>();
                EnemyAttackAgent enemyAttackAgent = enemy.GetComponent<EnemyAttackAgent>();

                sceneCycleController.RegisterSceneCycleService(enemyMoveAgent);
                sceneCycleController.RegisterSceneCycleService(enemyAttackAgent);
                enemyAttackAgent.SetTarget(_character);

                _enemyPool.Enqueue(enemy);
            }
        }

        public GameObject SpawnEnemy()
        {
            if (!_enemyPool.TryDequeue(out var enemy))
            {
                return null;
            }

            enemy.transform.SetParent(_worldTransform);

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            
            var attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(_container);
            _enemyPool.Enqueue(enemy);
        }


    }
}