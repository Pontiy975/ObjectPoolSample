using PoolingSystem;
using UnityEngine;

namespace Projectiles
{
    public class EnemyProjectile : PoolableObject
    {
        [SerializeField] private PoolController projectilePools;

        private Transform _transform;

        private void Start()
        {
            _transform = transform;
            //_poolManager = PoolManager.Instance;
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
            projectilePools.ReturnToPool(this);
        }
    }
}