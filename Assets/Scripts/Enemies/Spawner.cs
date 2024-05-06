using PoolingSystem;
using UnityEngine;

namespace Enemies
{
    public class Spawner : MonoBehaviour
    {
        private enum EnemyType { Enemy, Asteroid }

        [SerializeField] private float spawnCooldown;
        [SerializeField] private EnemyType enemyType;

        private PoolManager _poolManager;

        private float _timer;

        private void Start()
        {
            _timer = spawnCooldown;
            _poolManager = PoolManager.Instance;
        }

        private void Update()
        {
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0f)
            {
                _timer = spawnCooldown;
                Spawn();
            }
        }

        private void Spawn()
        {
            Transform enemyTransform = null;

            if (enemyType == EnemyType.Enemy)
                enemyTransform = _poolManager.GetFromPool<Enemy>(PoolType.Enemies).transform;
            else if (enemyType == EnemyType.Asteroid)
                enemyTransform = _poolManager.GetFromPool<Asteroid>(PoolType.Enemies).transform;

            enemyTransform.position = GetPoint();
        }

        private Vector2 GetPoint()
        {
            float x = Random.Range(ScreenSize.BottomLeft.x + 1f, ScreenSize.TopRight.x - 1f);
            return new Vector2(x, ScreenSize.TopRight.y);
        }
    }
}