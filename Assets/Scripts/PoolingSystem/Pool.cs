using System.Collections.Generic;
using UnityEngine;

namespace PoolingSystem
{
    [System.Serializable]
    public class Pool<T> where T : PoolableObject
    {
        [SerializeField] private T prefab;

        [Range(0, 100)][SerializeField] private int poolSize;

        private Stack<T> _pool = new Stack<T>();
        private Transform _container;

        public void Init(Transform globalContainer)
        {
            _container = new GameObject($"{prefab.GetType().Name}_Pool").transform;
            _container.SetParent(globalContainer);

            for (int i = 0; i < poolSize; i++)
            {
                SpawnItem(i);
            }
        }

        public T GetItem()
        {
            if (_pool == null)
                return default;

            if (_pool.Count == 0)
                SpawnItem(0);

            T item = _pool.Pop();
            item.OnSpawn();

            return item;
        }

        public void ReturnItem(T item)
        {
            _pool.Push(item);
            item.OnDespawn();
        }

        public void Clear()
        {
            _pool?.Clear();
            _pool = null;
        }

        public bool CheckItemType<S>()
        {
            return prefab != null && prefab.GetType() == typeof(S);
        }

        private void SpawnItem(int number)
        {
            T item = Object.Instantiate(prefab);

            _pool ??= new Stack<T>();
            _pool.Push(item);

            item.name += $" {number}";
            item.transform.SetParent(_container);
            item.OnDespawn();
        }
    }
}