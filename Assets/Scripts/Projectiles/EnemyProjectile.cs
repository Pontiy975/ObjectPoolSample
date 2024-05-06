using PoolingSystem;
using UnityEngine;

namespace Projectiles
{
    public class EnemyProjectile : PoolableObject
    {
        private Transform _transform;
        private PoolManager _poolManager;

        private void Start()
        {
            _transform = transform;
            _poolManager = PoolManager.Instance;
        }

        private void Update()
        {
            if (_transform.position.y <= ScreenSize.BottomLeft.y - 1f)
                ReturnToPool();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                ReturnToPool();
        }

        private void ReturnToPool()
        {
            _poolManager.ReturnToPool(PoolType.Projectiles, this);
        }
    }
}