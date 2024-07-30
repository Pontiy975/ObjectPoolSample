using PoolingSystem;
using UnityEngine;

public class Asteroid : PoolableObject
{
    [SerializeField] private PoolController enemyPools;

    private Transform _transform;
    
    private void Start()
    {
        _transform = transform;
        //_poolManager = PoolManager.Instance;
    }

    private void Update()
    {
        if (_transform.position.y <= ScreenSize.BottomLeft.y - 1f)
            enemyPools.ReturnToPool(this);
    }
}
