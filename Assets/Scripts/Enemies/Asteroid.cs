using PoolingSystem;
using UnityEngine;

public class Asteroid : PoolableObject
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
            _poolManager.ReturnToPool(PoolType.Enemies, this);
    }
}
